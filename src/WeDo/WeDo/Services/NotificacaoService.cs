using Microsoft.EntityFrameworkCore;
using WeDo.Models;

namespace WeDo.Services
{
    public class NotificacaoService
    {
        private readonly AppDbContext _context;

        public NotificacaoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task NotificarMetaRegistrada(int idUsuario, string nomeMeta)
        {
            var jaExiste = await _context.Notificacoes.AnyAsync(n =>
                n.IdUsuario == idUsuario &&
                n.Tipo == TipoNotificacao.MetaRegistrada &&
                n.Mensagem.Contains(nomeMeta) &&
                n.DataEnvio.Date == DateTime.Today);

            if (!jaExiste)
            {
                _context.Notificacoes.Add(new Notificacao
                {
                    IdUsuario = idUsuario,
                    Mensagem = $"✅ Nova meta registrada: {nomeMeta}",
                    Tipo = TipoNotificacao.MetaRegistrada,
                    DataEnvio = DateTime.Now
                });
                await _context.SaveChangesAsync();
            }
        }

        public async Task NotificarMetaConcluida(int idUsuario, string nomeMeta)
        {
            var jaExiste = await _context.Notificacoes.AnyAsync(n =>
                n.IdUsuario == idUsuario &&
                n.Tipo == TipoNotificacao.MetaConcluida &&
                n.Mensagem.Contains(nomeMeta));

            if (!jaExiste)
            {
                _context.Notificacoes.Add(new Notificacao
                {
                    IdUsuario = idUsuario,
                    Mensagem = $"🎉 Parabéns! Você concluiu a meta: {nomeMeta}",
                    Tipo = TipoNotificacao.MetaConcluida,
                    DataEnvio = DateTime.Now
                });
                await _context.SaveChangesAsync();
            }
        }
    }
}