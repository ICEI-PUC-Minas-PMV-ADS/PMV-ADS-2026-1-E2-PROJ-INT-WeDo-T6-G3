using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using WeDo.Models;

namespace WeDo.Controllers
{
    [Authorize]
    public class MuralController : Controller
    {
        private readonly AppDbContext _context;

        public MuralController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdStr, out int userId)) return RedirectToAction("Login", "Usuarios");

            // CORREÇÃO: Buscando pelo Enum correto (CondicaoMeta.Concluida) e pela foreign key certa (IdUsuarioMeta)
            var conquistas = await _context.Metas
                .Where(m => m.IdUsuarioMeta == userId && m.Condicao == CondicaoMeta.Concluida)
                .OrderByDescending(m => m.DataFinal)
                .ToListAsync();

            return View(conquistas);
        }
    }
}