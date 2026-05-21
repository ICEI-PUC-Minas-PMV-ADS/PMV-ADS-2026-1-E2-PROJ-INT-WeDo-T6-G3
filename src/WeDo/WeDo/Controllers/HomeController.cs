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

            var atvDiaria = _context.Metas.Where(m => m.IdUsuarioMeta == usuarioLogado                // quebrada ainda, vou continuar daqui
                                                 && m.Condicao != CondicaoMeta.Concluida
                                                 && dataHoje <= m.DataFinal
                                                 && diaDaSemana == m.Condicao.CompareTo(1);

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
