using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeDo.Models
{
    [Table("AtividadesDiarias")]
    public class AtividadeDiaria
    {
        [Key]
        public int Id { get; set; }

        public int IdMeta { get; set; }
        [ForeignKey("IdMeta")]
        public Meta Meta { get; set; }

        [Required(ErrorMessage = "O nome da atividade é obrigatório.")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public DateTime Data { get; set; }

        public string UrlFoto { get; set; }

        public AtividadeDiaria() { }

        public AtividadeDiaria(string nome, string descricao, DateTime data, string urlFoto)
        {
            Nome = nome;
            Descricao = descricao;
            Data = data;
            UrlFoto = urlFoto;
        }

        [Display(Name = "Status da Atividade")]
        public StatusAtividade? Status { get; set; } = StatusAtividade.Pendente;
    }

    public enum StatusAtividade
    {
        Pendente = 0,
        ParcialmenteConcluida = 1,
        Concluida = 2
    }
}