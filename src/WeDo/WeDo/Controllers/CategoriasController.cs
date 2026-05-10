using Microsoft.AspNetCore.Mvc;
using WeDo.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // IMPORTANTE: Adicione essa linha para o ToListAsync e FindAsync funcionarem

namespace WeDo.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        // 1. LISTAGEM (Index)
        public async Task<IActionResult> Index()
        {
            var categorias = await _context.Categorias.ToListAsync();
            return View(categorias);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoria);
                await _context.SaveChangesAsync();
                return RedirectToAction("Criar", "Metas");
            }
            return View(categoria);
        }

        // --- INÍCIO DA PARTE 2 (COLE ABAIXO) ---

        // 2. EDITAR (Abre a tela)
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null) return NotFound();

            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null) return NotFound();

            return View(categoria);
        }

        // 2. EDITAR (Salva as mudanças)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Categoria categoria)
        {
            if (id != categoria.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(categoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        // 3. EXCLUIR
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Excluir(int id)
        {
            // Verifica se existe alguma meta que usa essa categoria
            bool possuiMetas = await _context.Metas.AnyAsync(m => m.IdCategoriaMeta == id);

            if (possuiMetas)
            {
                // Se houver metas, cria um aviso para a tela
                TempData["Erro"] = "Não é possível excluir esta categoria pois existem metas vinculadas a ela. Exclua as metas primeiro.";
                return RedirectToAction(nameof(Index));
            }

            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria != null)
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
                TempData["Sucesso"] = "Categoria excluída com sucesso!";
            }

            return RedirectToAction(nameof(Index));
        }

        // --- FIM DA PARTE 2 ---
    }
}