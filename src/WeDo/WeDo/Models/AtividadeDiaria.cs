using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeDo.Models
{
    // Modelo que representa uma atividade gerada a partir de uma Meta no sistema.
    // Mapeado diretamente para a tabela "AtividadesDiarias" no banco de dados.
    [Table("AtividadesDiarias")]
    public class AtividadeDiaria
    {
        [Key]
        public int Id { get; set; }

        // Chave estrangeira que vincula esta atividade à sua meta de origem
        public int IdMeta { get; set; }

        [ForeignKey("IdMeta")]
        public Meta Meta { get; set; }

        [Required(ErrorMessage = "O nome da atividade é obrigatório.")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        // Data exata do dia em que a atividade precisa ser realizada
        public DateTime Data { get; set; }

        public string UrlFoto { get; set; }

        // Construtor padrão vazio exigido pelo Entity Framework para consultas no banco
        public AtividadeDiaria() { }

        public AtividadeDiaria(string nome, string descricao, DateTime data, string urlFoto)
        {
            Nome = nome;
            Descricao = descricao;
            Data = data;
            UrlFoto = urlFoto;
        }

        // Armazena o progresso atual. 
        // Já nasce como 'Pendente' (0) por padrão para evitar campos nulos indesejados ao criar uma nova atividade.
        [Display(Name = "Status da Atividade")]
        public StatusAtividade? Status { get; set; } = StatusAtividade.Pendente;
    }

    // Domínio de status permitidos para uma atividade.
    // A numeração explícita (0, 1, 2) garante que o banco de dados grave a ordem correta, facilitando consultas e lógicas futuras.
    public enum StatusAtividade
    {
        Pendente = 0,
        ParcialmenteConcluida = 1,
        Concluida = 2
    }
}