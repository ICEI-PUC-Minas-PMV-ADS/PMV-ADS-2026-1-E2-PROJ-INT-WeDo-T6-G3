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

        // Recupera o ID do usuário logado
        private int? ObterIdUsuarioLogado()
        {
            var idClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (int.TryParse(idClaim, out var id)) return id;
            return null;
        }

        // GET: /Notificacaos
        // Gera notificações automáticas e exibe todas do usuário
        public async Task<IActionResult> Index()
        {
            var idUsuario = ObterIdUsuarioLogado();
            if (idUsuario == null) return RedirectToAction("Login", "Usuarios");

            await GerarNotificacoesAutomaticas(idUsuario.Value);

            var notificacoes = await _context.Notificacoes
                .Where(n => n.IdUsuario == idUsuario)
                .OrderByDescending(n => n.DataEnvio)
                .ToListAsync();

            return View(notificacoes);
        }

        // POST: /Notificacaos/MarcarLida/5
        // Marca uma notificação como lida
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
                _context.Update(notificacao);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: /Notificacaos/MarcarTodasLidas
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarcarTodasLidas()
        {
            var idUsuario = ObterIdUsuarioLogado();
            var naoLidas = await _context.Notificacoes
                .Where(n => n.IdUsuario == idUsuario && !n.Lida)
                .ToListAsync();

            foreach (var n in naoLidas)
                n.Lida = true;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: /Notificacaos/Excluir/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Excluir(int id)
        {
            var idUsuario = ObterIdUsuarioLogado();
            var notificacao = await _context.Notificacoes
                .FirstOrDefaultAsync(n => n.Id == id && n.IdUsuario == idUsuario);

            if (notificacao != null)
            {
                _context.Notificacoes.Remove(notificacao);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: /Notificacaos/ExcluirLidas
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExcluirLidas()
        {
            var idUsuario = ObterIdUsuarioLogado();
            var lidas = await _context.Notificacoes
                .Where(n => n.IdUsuario == idUsuario && n.Lida)
                .ToListAsync();

            _context.Notificacoes.RemoveRange(lidas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // =====================================================
        // GERAÇÃO AUTOMÁTICA DE NOTIFICAÇÕES
        // =====================================================
        private async Task GerarNotificacoesAutomaticas(int idUsuario)
        {
            var hoje = DateTime.Today;

            var metas = await _context.Metas
                .Include(m => m.AtividadesDiarias)
                .Where(m => m.IdUsuarioMeta == idUsuario)
                .ToListAsync();

            foreach (var meta in metas)
            {
                // 1. Meta concluída — notifica uma vez
                if (meta.Condicao == CondicaoMeta.Concluida)
                {
                    var jaExiste = await _context.Notificacoes.AnyAsync(n =>
                        n.IdUsuario == idUsuario &&
                        n.Tipo == TipoNotificacao.MetaConcluida &&
                        n.Mensagem.Contains(meta.Nome));

                    if (!jaExiste)
                    {
                        _context.Notificacoes.Add(new Notificacao
                        {
                            IdUsuario = idUsuario,
                            Mensagem = $"Parabéns! Você concluiu a meta: {meta.Nome} 🎉",
                            Tipo = TipoNotificacao.MetaConcluida,
                            DataEnvio = DateTime.Now
                        });
                    }
                }

                // 2. Prazo próximo (5 dias ou menos) — notifica uma vez por meta
                var diasRestantes = (meta.DataFinal - hoje).Days;
                if (diasRestantes >= 0 && diasRestantes <= 5 && meta.Condicao != CondicaoMeta.Concluida)
                {
                    var jaExiste = await _context.Notificacoes.AnyAsync(n =>
                        n.IdUsuario == idUsuario &&
                        n.Tipo == TipoNotificacao.PrazoProximo &&
                        n.Mensagem.Contains(meta.Nome) &&
                        n.DataEnvio.Date == hoje);

                    if (!jaExiste)
                    {
                        var msg = diasRestantes == 0
                            ? $"⚠️ Hoje é o último dia para concluir: {meta.Nome}!"
                            : $"⚠️ A meta \"{meta.Nome}\" vence em {diasRestantes} dia(s)!";

                        _context.Notificacoes.Add(new Notificacao
                        {
                            IdUsuario = idUsuario,
                            Mensagem = msg,
                            Tipo = TipoNotificacao.PrazoProximo,
                            DataEnvio = DateTime.Now
                        });
                    }
                }

                // 3. Atividades do dia pendentes
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
                        .Any(a => a.Data.Date == hoje && a.Status != StatusAtividade.Pendente);

                    if (atividadeHoje == false || atividadeHoje == null)
                    {
                        var jaExiste = await _context.Notificacoes.AnyAsync(n =>
                            n.IdUsuario == idUsuario &&
                            n.Tipo == TipoNotificacao.AtividadePendente &&
                            n.Mensagem.Contains(meta.Nome) &&
                            n.DataEnvio.Date == hoje);

                        if (!jaExiste)
                        {
                            _context.Notificacoes.Add(new Notificacao
                            {
                                IdUsuario = idUsuario,
                                Mensagem = $"📋 Você ainda não registrou a atividade de hoje: {meta.Nome}",
                                Tipo = TipoNotificacao.AtividadePendente,
                                DataEnvio = DateTime.Now
                            });
                        }
                    }
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}