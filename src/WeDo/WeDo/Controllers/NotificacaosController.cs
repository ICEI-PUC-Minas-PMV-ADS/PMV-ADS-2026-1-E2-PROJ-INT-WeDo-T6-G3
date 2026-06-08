using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WeDo.Models;

namespace WeDo.Controllers
{
    [Authorize]
    public class NotificacaosController : Controller
    {
        private readonly AppDbContext _context;

        public NotificacaosController(AppDbContext context)
        {
            _context = context;
        }

        private int? ObterIdUsuarioLogado()
        {
            var idClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return int.TryParse(idClaim, out var id) ? id : null;
        }

        // GET: /Notificacaos
        public async Task<IActionResult> Index()
        {
            var idUsuario = ObterIdUsuarioLogado();
            if (idUsuario == null) return RedirectToAction("Login", "Usuarios");

            // Gera as notificações em tempo real
            await GerarNotificacoesAutomaticas(idUsuario.Value);

            // Filtragem: Não traz para a tela notificações que foram esvaziadas (excluídas)
            var notificacoes = await _context.Notificacoes
                .AsNoTracking()
                .Where(n => n.IdUsuario == idUsuario && n.Mensagem != "")
                .OrderByDescending(n => n.DataEnvio)
                .ToListAsync();

            return View(notificacoes);
        }

        // POST: Marca como lida
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarcarLida(int id)
        {
            var idUsuario = ObterIdUsuarioLogado();
            var notificacao = await _context.Notificacoes
                .FirstOrDefaultAsync(n => n.Id == id && n.IdUsuario == idUsuario);

            if (notificacao != null)
            {
                notificacao.Lida = true;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Marca todas como lidas
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarcarTodasLidas()
        {
            var idUsuario = ObterIdUsuarioLogado();

            await _context.Notificacoes
                .Where(n => n.IdUsuario == idUsuario && !n.Lida && n.Mensagem != "")
                .ExecuteUpdateAsync(s => s.SetProperty(n => n.Lida, true));

            return RedirectToAction(nameof(Index));
        }

        // POST: Exclui uma notificação específica
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Excluir(int id)
        {
            var idUsuario = ObterIdUsuarioLogado();

            // Em vez de apagar do banco, nós limpamos a mensagem. 
            // O registro continua lá (pro gerador não duplicar), mas some da tela do usuário.
            await _context.Notificacoes
                .Where(n => n.Id == id && n.IdUsuario == idUsuario)
                .ExecuteUpdateAsync(s => s.SetProperty(n => n.Mensagem, ""));

            return RedirectToAction(nameof(Index));
        }

        // POST: Exclui todas as lidas
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExcluirLidas()
        {
            var idUsuario = ObterIdUsuarioLogado();
            if (idUsuario == null) return RedirectToAction("Login", "Usuarios");

            // Esvazia as mensagens de todas as notificações lidas
            await _context.Notificacoes
                .Where(n => n.IdUsuario == idUsuario && n.Lida)
                .ExecuteUpdateAsync(s => s.SetProperty(n => n.Mensagem, ""));

            return RedirectToAction(nameof(Index));
        }

        // =====================================================
        // GERAÇÃO AUTOMÁTICA DE NOTIFICAÇÕES (IMEDIATA E SEGURA)
        // =====================================================
        private async Task GerarNotificacoesAutomaticas(int idUsuario)
        {
            var hoje = DateTime.Today;

            // Busca as notificações existentes (incluindo as que foram limpas)
            var notificacoesExistentes = await _context.Notificacoes
                .AsNoTracking()
                .Where(n => n.IdUsuario == idUsuario)
                .ToListAsync();

            var metas = await _context.Metas
                .Include(m => m.AtividadesDiarias)
                .Where(m => m.IdUsuarioMeta == idUsuario)
                .ToListAsync();

            var novasNotificacoes = new List<Notificacao>();

            foreach (var meta in metas)
            {
                // 1. Meta concluída (Geral do sistema)
                if (meta.Condicao == CondicaoMeta.Concluida)
                {
                    // Se já existir qualquer registro para essa meta (com texto ou vazio), não recria
                    var jaExiste = notificacoesExistentes.Any(n =>
                        n.Tipo == TipoNotificacao.MetaConcluida &&
                        (n.Mensagem.Contains(meta.Nome) || n.Mensagem == ""));

                    if (!jaExiste)
                    {
                        novasNotificacoes.Add(new Notificacao
                        {
                            IdUsuario = idUsuario,
                            Mensagem = $"Parabéns! Você concluiu a meta: {meta.Nome} 🎉",
                            Tipo = TipoNotificacao.MetaConcluida,
                            DataEnvio = DateTime.Now
                        });
                    }
                }

                // 2. Prazo próximo
                var diasRestantes = (meta.DataFinal - hoje).Days;
                if (diasRestantes >= 0 && diasRestantes <= 5 && meta.Condicao != CondicaoMeta.Concluida)
                {
                    var jaExiste = notificacoesExistentes.Any(n =>
                        n.Tipo == TipoNotificacao.PrazoProximo &&
                        n.DataEnvio.Date == hoje);

                    if (!jaExiste)
                    {
                        var msg = diasRestantes == 0
                            ? $"⚠️ Hoje é o último dia para concluir: {meta.Nome}!"
                            : $"⚠️ A meta \"{meta.Nome}\" vence em {diasRestantes} dia(s)!";

                        novasNotificacoes.Add(new Notificacao
                        {
                            IdUsuario = idUsuario,
                            Mensagem = msg,
                            Tipo = TipoNotificacao.PrazoProximo,
                            DataEnvio = DateTime.Now
                        });
                    }
                }

                // 3. Atividade pendente
                var diasSemana = new Dictionary<DayOfWeek, bool>
                {
                    { DayOfWeek.Sunday, meta.Domingo },
                    { DayOfWeek.Monday, meta.Segunda },
                    { DayOfWeek.Tuesday, meta.Terca },
                    { DayOfWeek.Wednesday, meta.Quarta },
                    { DayOfWeek.Thursday, meta.Quinta },
                    { DayOfWeek.Friday, meta.Sexta },
                    { DayOfWeek.Saturday, meta.Sabado }
                };

                var metaAtiva = meta.Condicao != CondicaoMeta.Concluida
                             && meta.DataInicial.Date <= hoje
                             && meta.DataFinal.Date >= hoje;

                if (metaAtiva && diasSemana.TryGetValue(hoje.DayOfWeek, out var ativaHoje) && ativaHoje)
                {
                    var atividadeHoje = meta.AtividadesDiarias?
                        .Any(a => a.Data.Date == hoje && a.Status != StatusAtividade.Pendente && a.Status.ToString().ToLower() != "pendente");

                    if (atividadeHoje == false || atividadeHoje == null)
                    {
                        var jaExiste = notificacoesExistentes.Any(n =>
                            n.Tipo == TipoNotificacao.AtividadePendente &&
                            n.DataEnvio.Date == hoje);

                        if (!jaExiste)
                        {
                            novasNotificacoes.Add(new Notificacao
                            {
                                IdUsuario = idUsuario,
                                Mensagem = $"📋 Você ainda não registrou a atividade de hoje: {meta.Nome}",
                                Tipo = TipoNotificacao.AtividadePendente,
                                DataEnvio = DateTime.Now
                            });
                        }
                    }
                }

                // 4. REGRA: ATIVIDADE DA DASHBOARD CONCLUÍDA HOJE
                if (meta.AtividadesDiarias != null)
                {
                    var concluidaHoje = meta.AtividadesDiarias.Any(a =>
                        a.Data.Date == hoje &&
                        (a.Status == StatusAtividade.Concluida ||
                         a.Status.ToString().Equals("Concluida", StringComparison.OrdinalIgnoreCase) ||
                         a.Status.ToString().Equals("Concluido", StringComparison.OrdinalIgnoreCase)));

                    if (concluidaHoje)
                    {
                        // Se já existir uma notificação criada HOJE para essa regra, ele não duplica (mesmo que esteja vazia)
                        var jaMencionouHoje = notificacoesExistentes.Any(n =>
                            n.DataEnvio.Date == hoje &&
                            n.Tipo == TipoNotificacao.MetaConcluida &&
                            (n.Mensagem.Contains(meta.Nome) || n.Mensagem == ""));

                        if (!jaMencionouHoje)
                        {
                            novasNotificacoes.Add(new Notificacao
                            {
                                IdUsuario = idUsuario,
                                Mensagem = $"🎉 Muito bem! Você concluiu a atividade de hoje: {meta.Nome}",
                                Tipo = TipoNotificacao.MetaConcluida,
                                DataEnvio = DateTime.Now
                            });
                        }
                    }
                }
            }

            if (novasNotificacoes.Any())
            {
                await _context.Notificacoes.AddRangeAsync(novasNotificacoes);
                await _context.SaveChangesAsync();
            }
        }
    }
}