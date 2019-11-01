using System.ComponentModel.DataAnnotations;

namespace Caelum.Fn23.Blog.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Usuário", Prompt = "Digite seu nome de usuário")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email", Prompt = "Digite seu endereço de email")]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required]
        [Compare("Senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmação de senha")]
        public string ConfirmacaoSenha { get; set; }
    }
}
