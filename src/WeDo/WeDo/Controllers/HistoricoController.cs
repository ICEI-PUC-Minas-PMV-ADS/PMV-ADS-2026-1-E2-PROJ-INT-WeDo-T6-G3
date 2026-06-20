using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WeDo.Models;
using WeDo.Models.ViewModels;

namespace WeDo.Controllers
{
    [Authorize]
    public class HistoricoController : Controller
    {
        private readonly AppDbContext _context;

        public HistoricoController(AppDbContext context)
        {
            _context = context;
        }

        private int? ObterIdUsuarioLogado()
        {
            var idClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (int.TryParse(idClaim, out var id)) return id;
            return null;
        }

        // GET: /Historico
        public async Task<IActionResult> Index(int? mes, int? ano, int? categoriaId, int? metaId)
        {
            var idUsuario = ObterIdUsuarioLogado();
            if (idUsuario == null) return RedirectToAction("Login", "Usuarios");

            var hoje = DateTime.Today;
            var mesAtual = mes ?? hoje.Month;
            var anoAtual = ano ?? hoje.Year;

            var queryMetas = _context.Metas
                .Include(m => m.Categoria)
                .Include(m => m.AtividadesDiarias)
                .Where(m => m.IdUsuarioMeta == idUsuario);

            if (categoriaId.HasValue && categoriaId > 0)
                queryMetas = queryMetas.Where(m => m.IdCategoriaMeta == categoriaId);

            var metas = await queryMetas.ToListAsync();

            int? metaSelecionadaId = metaId;
            if (metaSelecionadaId == null || !metas.Any(m => m.Id == metaSelecionadaId))
                metaSelecionadaId = metas.FirstOrDefault()?.Id;

            var categorias = await _context.Categorias.ToListAsync();

            var viewModel = new HistoricoViewModel
            {
                Metas = metas,
                MesAtual = mesAtual,
                AnoAtual = anoAtual,
                Categorias = categorias,
                CategoriaFiltradaId = categoriaId,
                MetaSelecionadaId = metaSelecionadaId
            };

            return View(viewModel);
        }
    }
}