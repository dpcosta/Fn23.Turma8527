using Caelum.Fn23.Blog.Infra;
using Caelum.Fn23.Blog.Models;

namespace Caelum.Fn23.Blog.DAL
{
    public class UsuarioDAO : BaseDAO<Usuario>, IUsuarioDAO
    {
        public UsuarioDAO(BlogContext context) : base(context)
        {
        }
    }
}
