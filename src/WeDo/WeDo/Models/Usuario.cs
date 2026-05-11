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
        [Display(Name = "Nome completo")]
        public string Nome { get; set; }

        [Display(Name = "Apelido")]
        public string Apelido { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "URL da foto")]
        public string UrlFoto { get; set; }

        [Required(ErrorMessage = "Obrigatorio preecher seu email")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatorio preecher sua senha")]
        public string Senha { get; set; }

        //recuperacao de senha----
        public string? TokenRecuperacao { get; set; }
        public DateTime? DataExpiracaoToken { get; set; }
        //------------------------

        // Preferências do usuário (Configurações Gerais)
        [Display(Name = "Idioma")]
        public Idioma Idioma { get; set; } = Idioma.PortuguesBR;

        [Display(Name = "Tema")]
        public Tema Tema { get; set; } = Tema.Claro;

        [Display(Name = "Notificações por e-mail")]
        public bool NotificacoesEmail { get; set; } = true;

        [Display(Name = "Notificações por push")]
        public bool NotificacoesPush { get; set; } = true;

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

    public enum Idioma { PortuguesBR, InglesUS, EspanholES }
    public enum Tema { Claro, Escuro }
}