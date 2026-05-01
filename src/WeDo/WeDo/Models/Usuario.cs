using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeDo.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatorio preecher seu nome")]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string UrlFoto { get; set; }

        [Required(ErrorMessage = "Obrigatorio preecher seu email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatorio preecher sua senha")]
        public string Senha { get; set; }

        public ICollection<Meta> Metas { get; set; }                   // Relacionamento um-para-muitos com a tabela de metas

        public Usuario() { }
        public Usuario(string nome, string descricao, string urlFoto, string email, string senha)
        {
            Nome = nome;
            Descricao = descricao;
            UrlFoto = urlFoto;
            Email = email;
            Senha = senha;
        }

    }
}