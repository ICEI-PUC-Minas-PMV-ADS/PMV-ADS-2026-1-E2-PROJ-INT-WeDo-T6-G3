using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeDo.Models;

namespace WeDo.Controllers
{
    public class AtividadesDiariasController : Controller
    {
        private readonly AppDbContext _context;

        public AtividadesDiariasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: AtividadesDiarias/Registrar
        public IActionResult Registrar()
        {
            // Carrega a lista de metas para o usuário escolher uma no formulário
            ViewBag.IdMeta = new SelectList(_context.Metas, "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrar([Bind("Nome,Descricao,Data,UrlFoto,IdMeta")] AtividadeDiaria atividade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atividade);
                await _context.SaveChangesAsync();

                // Após registrar, você pode mandar ele para o Histórico ou para a lista de metas
                return RedirectToAction("Index", "Metas");
            }

            ViewBag.IdMeta = new SelectList(_context.Metas, "Id", "Nome", atividade.IdMeta);
            return View(atividade);
        }
    }
}