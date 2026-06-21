using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeDo.Models
{
    [Table("Notificacoes")]
    public class Notificacao
    {
        [Key]
        public int Id { get; set; }

        // Vínculo com o usuário dono da notificação
        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [Required]
        public string Mensagem { get; set; }

        public DateTime DataEnvio { get; set; } = DateTime.Now;

        public bool Lida { get; set; } = false;

        // Tipo da notificação para exibir ícone diferente
        public TipoNotificacao Tipo { get; set; } = TipoNotificacao.Geral;
    }

    public enum TipoNotificacao
    {
        Geral = 0,
        MetaConcluida = 1,
        MetaRegistrada = 2,
        PrazoProximo = 3,
        AtividadePendente = 4
    }
}
