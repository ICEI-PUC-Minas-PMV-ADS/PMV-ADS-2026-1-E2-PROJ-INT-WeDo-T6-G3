using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WeDo.Models;
using WeDo.Models.ViewModels;

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

            List<DashboardViewModel> listaAtvDiaria = new List<DashboardViewModel>();

            foreach (var atv in atvDiaria)
            {
                var atividadeHoje = await _context.AtividadesDiarias.FirstOrDefaultAsync(a => a.IdMeta == atv.Id && a.Data == dataHoje);

                // LIMPEZA: Volta a usar o Enum nativo. Se não houver atividade no banco hoje, o status será Pendente (0).
                var statusAtual = atividadeHoje?.Status ?? StatusAtividade.Pendente;

                var modelo = new DashboardViewModel
                {
                    MetaId = atv.Id,
                    NomeMetaPai = atv.Nome,
                    NomeAtividade = atv.Nome,
                    DescricaoAtividade = atv.Descricao,
                    AtividadeId = atividadeHoje?.Id ?? 0,

                    // Envia o Enum exato para a tela e guarda o original para comparar depois
                    StatusHoje = statusAtual,
                    StatusOriginal = statusAtual
                };

                listaAtvDiaria.Add(modelo);
            }
            return View(listaAtvDiaria);
        }

        [HttpPost]
        public async Task<IActionResult> Atualizar(List<DashboardViewModel> model)
        {
            if (model == null || !model.Any())
                return RedirectToAction(nameof(Index));

            foreach (var item in model)
            {
                // PROTEÇÃO: Se o usuário não alterou o Dropdown na tela, ignora a linha e não vai ao banco!
                if (item.StatusHoje == item.StatusOriginal)
                    continue;

                // PROTEÇÃO 2: Se a atividade não existe no banco e o usuário deixou como Pendente, ignoramos para não criar lixo (0).
                if (item.AtividadeId == 0 && item.StatusHoje == StatusAtividade.Pendente)
                    continue;

                if (item.AtividadeId == 0)
                {
                    var novaAtividade = new AtividadeDiaria
                    {
                        IdMeta = item.MetaId,
                        Nome = item.NomeAtividade,
                        Descricao = item.DescricaoAtividade,
                        Data = DateTime.Today,
                        Status = item.StatusHoje // Salva o Enum diretamente, sem conversões!
                    };
                    _context.AtividadesDiarias.Add(novaAtividade);
                }
                else
                {
                    var atividadeExistente = await _context.AtividadesDiarias.FindAsync(item.AtividadeId);
                    if (atividadeExistente != null)
                    {
                        atividadeExistente.Status = item.StatusHoje; // Atualiza o Enum diretamente!
                        _context.Update(atividadeExistente);
                    }
                }
            }

            await _context.SaveChangesAsync();
            TempData["Mensagem"] = "Progresso salvo com sucesso!";
            return RedirectToAction(nameof(Index));
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