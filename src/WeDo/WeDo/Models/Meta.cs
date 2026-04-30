using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WeDo.Models
{
	[Table("Metas")]                                               // Nome da tabela no banco de dados
    public class Meta
	{
        [Key]                                                      // Chave primária
        public int Id { get; set; }
        
        public int IdUsuarioMeta { get; set; }                            // Chave estrangeira para o usuário associado à meta

        [ForeignKey("IdUsuarioMeta")]                                    // Chave estrangeira para a tabela de usuários
        public Usuario Usuario { get; set; }

        [Required(ErrorMessage = "O nome da meta é obrigatório.")] // Validação de campo obrigatório
        public string Nome { get; set; }

        [Display(Name= "Descrição")]                                
        public string Descricao { get; set; }

        [Display(Name = "Data de Inicio")]                         // Exibe um rótulo personalizado para o campo
        public DateTime DataInicial{ get; set; }

        [Display(Name = "Data de Término")]
        public DateTime DataFinal { get; set; }

        public DiasDaSemana Dias { get; set; }                     // Dias Da semana para caso seja exibida diariamente

        [Display(Name = "Condição")]
        public CondicaoMeta Condicao { get; set; }                 // Condição da meta (Pendente ou Concluída)
 
    }
    public enum CondicaoMeta { Iniciada, EmAndamento, Concluida }
    public enum DiasDaSemana { Segunda, Terca, Quarta, Quinta, Sexta, Sabado, Domingo }

}