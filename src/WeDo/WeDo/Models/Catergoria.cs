using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeDo.Models
{
	[Table("Categorias")]
	public class Categoria
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "O nome da categoria é obrigatório.")]
		public string Nome { get; set; }

		[Display(Name = "Descrição")]
		public string Descricao { get; set; }

		[Display (Name = "Cor")]
		public Cor CorCategoria { get; set; }

		public Categoria() { }

		public Categoria(string nome, string descricao, Cor corCategoria)
		{
			Nome = nome;
			Descricao = descricao;
			CorCategoria = corCategoria;
        }
        public ICollection<Meta> Metas { get; set; }                   // Relacionamento um-para-muitos com a tabela de metas

    }
    public enum Cor { Vermelho, Laranja, Amarelo, Verde, Azul, Roxo, Cinza}
    }
