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
		
		public int IdMeta { get; set; }                           // Chave estrangeira para a meta associada à atividade diária
        [ForeignKey("IdMeta")]                                    // Chave estrangeira para a tabela de metas
		public Meta Meta { get; set; }                         // Relacionamento com a tabela de metas

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

	}
}