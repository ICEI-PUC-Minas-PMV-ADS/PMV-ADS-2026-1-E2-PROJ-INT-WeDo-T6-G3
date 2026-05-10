using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeDo.Models;

namespace WeDo.Controllers
{
    public class MetasController : Controller
    {
        private readonly AppDbContext _context;

        public MetasController(AppDbContext context)
        {
            _context = context;
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
            meta.IdUsuarioMeta = 1;
            ModelState.Remove("Usuario");
            ModelState.Remove("IdUsuarioMeta");

            if (ModelState.IsValid)
            {
                _context.Add(meta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.IdCategoriaMeta = new SelectList(_context.Categorias.ToList(), "Id", "Nome", meta.IdCategoriaMeta);
            return View(meta);
        }

        public async Task<IActionResult> Index(int? categoriaId)
        {
            var metasQuery = _context.Metas.Include(m => m.Categoria).AsQueryable();

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

            meta.IdUsuarioMeta = 1;
            ModelState.Remove("Usuario");
            ModelState.Remove("IdUsuarioMeta");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meta);
                    await _context.SaveChangesAsync();
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