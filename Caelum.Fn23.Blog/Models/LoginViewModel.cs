using System.ComponentModel.DataAnnotations;

namespace Caelum.Fn23.Blog.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name ="Usuário")]
        public string Login { get; set; }
        [Required]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
