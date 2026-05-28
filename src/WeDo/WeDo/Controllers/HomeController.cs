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
               var atividadeHoje = await _context.AtividadesDiarias.FirstOrDefaultAsync(a => a.IdMeta == atv.Id && a.Data == dataHoje);    //calcular o status da atividade diária de acordo com a data e o status registrado
                var modelo = new DashboardViewModel
                {
                    // setando os valores no modelo a ser exibido na view
                    MetaId = atv.Id,
                    NomeMetaPai = atv.Nome,
                    NomeAtividade = atv.Nome,
                    DescricaoAtividade = atv.Descricao,

                    // Se a atividade existir, pega o ID dela. Se for nula, o ID é 0
                    AtividadeId = atividadeHoje?.Id ?? 0,

                    // Se a atividade existir, pega o Status dela. Se for nula, fica Pendente
                    StatusHoje = atividadeHoje?.Status ?? StatusAtividade.Pendente
                };

                // Adiciona na lista
                listaAtvDiaria.Add(modelo);
            }
            return View(listaAtvDiaria);

        }
        [HttpPost]
        public async Task<IActionResult> Atualizar(List<DashboardViewModel> listaAtvDiaria)
        {
            if (listaAtvDiaria == null || !listaAtvDiaria.Any())
                return RedirectToAction(nameof(Index));

            foreach (var item in listaAtvDiaria)
            {
                // Se a atividade não existe (Id == 0) e continua pendente, ignoramos para não sujar o banco
                if (item.AtividadeId == 0 && item.StatusHoje == StatusAtividade.Pendente)
                    continue;

                if (item.AtividadeId == 0)
                {
                    // O "Fantasma" virou real: Usuário marcou como Concluída/Cancelada
                    var novaAtividade = new AtividadeDiaria
                    {
                        IdMeta = item.MetaId,
                        Nome = item.NomeAtividade,
                        Descricao = item.DescricaoAtividade,
                        Data = DateTime.Today,
                        Status = item.StatusHoje
                    };
                    _context.AtividadesDiarias.Add(novaAtividade);
                }
                else
                {
                    // A atividade já existia hoje: Apenas atualizamos o status
                    var atividadeExistente = await _context.AtividadesDiarias.FindAsync(item.AtividadeId);
                    if (atividadeExistente != null)
                    {
                        atividadeExistente.Status = item.StatusHoje;
                        _context.Update(atividadeExistente);
                    }
                }
            }

            // Salva tudo de uma vez só no banco!
            await _context.SaveChangesAsync();

            // Recarrega a tela inicial
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