using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WeDo.Models;
using WeDo.Services;

namespace WeDo.Controllers
{
    [Authorize]
    public class MetasController : Controller
    {
        private readonly AppDbContext _context;
        private readonly NotificacaoService _notificacaoService;

        public MetasController(AppDbContext context, NotificacaoService notificacaoService)
        {
            _context = context;
            _notificacaoService = notificacaoService;
        }

        private int ObterIdUsuarioLogado()
        {
            var idClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return int.Parse(idClaim ?? "0");
        }

        public IActionResult Criar()
        {
            ViewBag.IdCategoriaMeta = new SelectList(_context.Categorias.ToList(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(Meta meta)
        {
            meta.IdUsuarioMeta = ObterIdUsuarioLogado();
            ModelState.Remove("Usuario");
            ModelState.Remove("IdUsuarioMeta");

            if (ModelState.IsValid)
            {
                _context.Add(meta);
                await _context.SaveChangesAsync();

                // Notifica que uma nova meta foi registrada
                await _notificacaoService.NotificarMetaRegistrada(meta.IdUsuarioMeta, meta.Nome);

                return RedirectToAction(nameof(Index));
            }

            ViewBag.IdCategoriaMeta = new SelectList(_context.Categorias.ToList(), "Id", "Nome", meta.IdCategoriaMeta);
            return View(meta);
        }

        public async Task<IActionResult> Index(int? categoriaId)
        {
            var idUsuario = ObterIdUsuarioLogado();
            var metasQuery = _context.Metas
                .Include(m => m.Categoria)
                .Where(m => m.IdUsuarioMeta == idUsuario)
                .AsQueryable();

            if (categoriaId.HasValue)
            {
                metasQuery = metasQuery.Where(m => m.IdCategoriaMeta == categoriaId);
            }

            ViewBag.Categorias = new SelectList(_context.Categorias, "Id", "Nome");
            return View(await metasQuery.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var meta = await _context.Metas
                .Include(m => m.Categoria)
                .Include(m => m.AtividadesDiarias)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (meta == null) return NotFound();

            return View(meta);
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null) return NotFound();
            var meta = await _context.Metas.FindAsync(id);
            if (meta == null) return NotFound();

            ViewBag.IdCategoriaMeta = new SelectList(_context.Categorias, "Id", "Nome", meta.IdCategoriaMeta);
            return View(meta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Meta meta)
        {
            if (id != meta.Id) return NotFound();

            meta.IdUsuarioMeta = ObterIdUsuarioLogado();
            ModelState.Remove("Usuario");
            ModelState.Remove("IdUsuarioMeta");

            if (ModelState.IsValid)
            {
                try
                {
                    // ADICIONADO: Verifica o estado anterior da meta para evitar spam de notificações
                    var metaNoBanco = await _context.Metas
                        .AsNoTracking()
                        .FirstOrDefaultAsync(m => m.Id == id);

                    _context.Update(meta);
                    await _context.SaveChangesAsync();

                    // Notifica se a meta foi concluída AGORA (evita enviar toda vez que editar a meta já concluída)
                    if (meta.Condicao == CondicaoMeta.Concluida && (metaNoBanco == null || metaNoBanco.Condicao != CondicaoMeta.Concluida))
                        await _notificacaoService.NotificarMetaConcluida(meta.IdUsuarioMeta, meta.Nome);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Metas.Any(e => e.Id == meta.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.IdCategoriaMeta = new SelectList(_context.Categorias, "Id", "Nome", meta.IdCategoriaMeta);
            return View(meta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Excluir(int id)
        {
            var meta = await _context.Metas.FindAsync(id);
            if (meta != null)
            {
                _context.Metas.Remove(meta);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}