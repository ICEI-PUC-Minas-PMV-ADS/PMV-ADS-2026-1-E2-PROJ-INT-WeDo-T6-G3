using System.ComponentModel.DataAnnotations;

namespace WeDo.Models
{
    public class Notificacao
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a mensagem")]
        public string Mensagem { get; set; }

        public DateTime DataEnvio { get; set; } = DateTime.Now;

        public bool Lida { get; set; } = false;
    }
}