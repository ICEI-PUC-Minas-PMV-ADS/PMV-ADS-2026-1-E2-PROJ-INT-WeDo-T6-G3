using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WeDo.Models;
namespace WeDo.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            int usuarioLogado = 1; // ID fixo apenas para testes 
            DateTime dataHoje = DateTime.Today;
            DayOfWeek diaDaSemana = dataHoje.DayOfWeek;

              var atvDiaria = await _context.Metas.Where(m => m.IdUsuarioMeta == usuarioLogado
                                                 && m.Condicao != CondicaoMeta.Concluida
                                                 && dataHoje <= m.DataFinal
                                                 && (diaDaSemana == DayOfWeek.Monday && m.Segunda
                                                 || diaDaSemana == DayOfWeek.Tuesday && m.Terca
                                                 || diaDaSemana == DayOfWeek.Wednesday && m.Quarta
                                                 || diaDaSemana == DayOfWeek.Thursday && m.Quinta
                                                 || diaDaSemana == DayOfWeek.Friday && m.Sexta
                                                 || diaDaSemana == DayOfWeek.Saturday && m.Sabado
                                                 || diaDaSemana == DayOfWeek.Sunday && m.Domingo)
            ).ToListAsync();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
