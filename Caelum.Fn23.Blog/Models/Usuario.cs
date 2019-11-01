using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Caelum.Fn23.Blog.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        
        [Required]
        public string Nome { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Senha { get; set; }

        public IEnumerable<Post> Posts { get; set; }
    }
}
