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

       
        public IActionResult Registrar()
        {
            
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

                
                return RedirectToAction("Index", "Metas");
            }

            ViewBag.IdMeta = new SelectList(_context.Metas, "Id", "Nome", atividade.IdMeta);
            return View(atividade);
        }
    }
}