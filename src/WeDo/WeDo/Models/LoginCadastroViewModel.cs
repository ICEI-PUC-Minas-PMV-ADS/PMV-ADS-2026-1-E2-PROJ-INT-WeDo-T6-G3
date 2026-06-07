using System.ComponentModel.DataAnnotations;

namespace WeDo.Models.ViewModels
{
    public class LoginCadastroViewModel
    {
        // --- Campos do Formulário de Cadastro ---
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string CadNome { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string CadEmail { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
        public string CadSenha { get; set; }

        // --- Campos do Formulário de Login ---
        [Required(ErrorMessage = "O e-mail de login é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string LoginEmail { get; set; }

        [Required(ErrorMessage = "A senha de login é obrigatória.")]
        public string LoginSenha { get; set; }
    }
}
