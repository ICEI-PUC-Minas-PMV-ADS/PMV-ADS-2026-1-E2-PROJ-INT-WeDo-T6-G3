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
                    var metaNoBanco = await _context.Metas
                        .AsNoTracking()
                        .FirstOrDefaultAsync(m => m.Id == id);

                    _context.Update(meta);
                    await _context.SaveChangesAsync();

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

        [HttpPost]                                                                           // Define verbo HTTP POST para a requisição
        [ValidateAntiForgeryToken]                                                           // Previne ataques de falsificação de solicitação entre sites (CSRF)
        public async Task<IActionResult> ConcluirMeta(int id)                                // Ação responsável por atualizar o status da meta para concluída
        {
            var meta = await _context.Metas.FindAsync(id);                                     // Busca a entidade Meta correspondente no banco de dados

            if (meta == null || meta.IdUsuarioMeta != ObterIdUsuarioLogado())                // Valida a existência da meta e a autorização do usuário logado
            {
                return NotFound();                                                           // Retorna código 404 caso a validação falhe
            }

            if (meta.Condicao == CondicaoMeta.Concluida)                                     // Verifica se a meta já se encontra finalizada
            {
                return RedirectToAction(nameof(Index));                                      // Interrompe a execução e retorna à listagem principal
            }

            meta.Condicao = CondicaoMeta.Concluida;                                          // Atualiza o enumerador de condição da meta
            _context.Update(meta);                                                           // Prepara o contexto do Entity Framework para a modificação
            await _context.SaveChangesAsync();                                               // Persiste as alterações no banco de dados

            await _notificacaoService.NotificarMetaConcluida(meta.IdUsuarioMeta, meta.Nome); // Dispara serviço de notificação ao usuário

            return RedirectToAction(nameof(Index));                                          // Redireciona para a view Index após o término da operação
        }
    }
}