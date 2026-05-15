using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WeDo.Models
{
	[Table("Metas")]                                                     // Nome da tabela no banco de dados
    public class Meta
	{
        [Key]                                                            // Chave primária
        public int Id { get; set; }
        
        public int IdUsuarioMeta { get; set; }                           // Chave estrangeira para o usuário associado à meta
        [ForeignKey("IdUsuarioMeta")]                                    // Chave estrangeira para a tabela de usuários
        public Usuario Usuario { get; set; }

        public int IdCategoriaMeta { get; set; }                         // Chave estrangeira para a categoria da meta
        [ForeignKey("IdCategoriaMeta")]                                  // Chave estrangeira para a tabela de categorias
        public Categoria Categoria { get; set; }                         // Relacionamento com a tabela de categorias

        [Required(ErrorMessage = "O nome da meta é obrigatório.")]       // Validação de campo obrigatório
        public string Nome { get; set; }

        [Display(Name= "Descrição")]             
        public string Descricao { get; set; }

        [Display(Name = "Data de Inicio")]                         // Exibe um rótulo personalizado para o campo
        public DateTime DataInicial{ get; set; }

        [Display(Name = "Data de Término")]
        public DateTime DataFinal { get; set; }


        [Display(Name = "Condição")]
        public CondicaoMeta Condicao { get; set; }                 // Condição da meta (Pendente ou Concluída)
        
        public bool Domingo { get; set; }
        public bool Segunda { get; set; }
        public bool Terca { get; set; }
        public bool Quarta { get; set; }
        public bool Quinta { get; set; }
        public bool Sexta { get; set; }
        public bool Sabado { get; set; }

        public Meta() { }                                          // Construtor padrão

        public Meta(int idUsuarioMeta, int idCategoriaMeta, string nome, string descricao, DateTime dataInicial, DateTime dataFinal, CondicaoMeta condicao,
            bool domingo, bool segunda, bool terca, bool quarta, bool quinta, bool sexta, bool sabado)
        {
            IdUsuarioMeta = idUsuarioMeta;
            IdCategoriaMeta = idCategoriaMeta;
            Nome = nome;
            Descricao = descricao;
            DataInicial = dataInicial;
            DataFinal = dataFinal;
            Condicao = condicao;
            Domingo = domingo;
            Segunda = segunda;
            Terca = terca;
            Quarta = quarta;
            Quinta = quinta;
            Sexta = sexta;
            Sabado = sabado;
        }
        public virtual ICollection<AtividadeDiaria> AtividadesDiarias  { get; set; }                   // Relacionamento um-para-muitos com a tabela de metas

    }
    public enum CondicaoMeta { Iniciada, EmAndamento, Concluida }

}