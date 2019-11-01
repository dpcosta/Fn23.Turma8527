using System.Collections.Generic;
using Caelum.Fn23.Blog.Infra;
using Caelum.Fn23.Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Caelum.Fn23.Blog.DAL
{
    public class PostDAO : BaseDAO<Post>, IPostDAO
    {
        public PostDAO(BlogContext context) : base(context)
        {
        }

        public override void Alterar(Post obj)
        {
            context.Usuarios.Attach(obj.Autor);
            base.Alterar(obj);
        }

        public override void Incluir(Post obj)
        {
            context.Usuarios.Attach(obj.Autor);
            base.Incluir(obj);
        }

        public override IEnumerable<Post> Todos => context.Posts.Include(p => p.Autor);
    }
}
