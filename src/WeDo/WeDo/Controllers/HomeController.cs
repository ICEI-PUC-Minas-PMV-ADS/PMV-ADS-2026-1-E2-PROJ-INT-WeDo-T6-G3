using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WeDo.Models;
using WeDo.Models.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeDo.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        // Carrega o painel principal (Dashboard) garantindo que apenas usuários autenticados tenham acesso.
        [Authorize]
        public async Task<IActionResult> Index()
        {
            // Recupera o ID do usuário autenticado no cookie da sessão.
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userIdClaim))
                return RedirectToAction("Login", "Usuarios");

            int usuarioLogado = int.Parse(userIdClaim);
            DateTime dataHoje = DateTime.Today;
            DayOfWeek diaDaSemana = dataHoje.DayOfWeek;

            // Busca as metas do usuário que estão ativas, dentro do prazo e programadas para o dia da semana atual.
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
                // Verifica se já existe um registro de atividade correspondente a esta meta para o dia atual.
                var atividadeHoje = await _context.AtividadesDiarias.FirstOrDefaultAsync(a => a.IdMeta == atv.Id && a.Data == dataHoje);

                // Define o status da atividade. Se ainda não existir no banco, assume o status padrão (Pendente).
                var statusAtual = atividadeHoje?.Status ?? StatusAtividade.Pendente;

                var modelo = new DashboardViewModel
                {
                    MetaId = atv.Id,
                    NomeMetaPai = atv.Nome,
                    NomeAtividade = atv.Nome,
                    DescricaoAtividade = atv.Descricao,
                    AtividadeId = atividadeHoje?.Id ?? 0,
                    StatusHoje = statusAtual,
                    StatusOriginal = statusAtual
                };

                listaAtvDiaria.Add(modelo);
            }

            return View(listaAtvDiaria);
        }

        // Processa o formulário da Dashboard e persiste as atualizações de status no banco de dados.
        [HttpPost]
        public async Task<IActionResult> Atualizar(List<DashboardViewModel> model)
        {
            if (model == null || !model.Any())
                return RedirectToAction(nameof(Index));

            foreach (var item in model)
            {
                // Ignora o registro caso o usuário não tenha alterado o status na interface (Dirty check).
                if (item.StatusHoje == item.StatusOriginal)
                    continue;

                // Evita a criação de registros no banco se a atividade não existir e o status for mantido como Pendente.
                if (item.AtividadeId == 0 && item.StatusHoje == StatusAtividade.Pendente)
                    continue;

                if (item.AtividadeId == 0)
                {
                    // Cria um novo registro de atividade diária para a meta correspondente.
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
                    // Atualiza o status de uma atividade diária já existente.
                    var atividadeExistente = await _context.AtividadesDiarias.FindAsync(item.AtividadeId);
                    if (atividadeExistente != null)
                    {
                        atividadeExistente.Status = item.StatusHoje;
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