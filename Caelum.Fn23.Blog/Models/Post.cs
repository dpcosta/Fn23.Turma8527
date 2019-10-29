using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caelum.Fn23.Blog.Models
{
    public class Post
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        [Column(TypeName="varchar(50)")]
        public string Titulo { get; set; }
        
        [StringLength(500)]
        [Column(TypeName = "varchar(500)")]
        public string Resumo { get; set; }

        public string Categoria { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public bool Publicado { get; set; }

    }
}
