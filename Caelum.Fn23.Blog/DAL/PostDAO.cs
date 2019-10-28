using Caelum.Fn23.Blog.Infra;
using Caelum.Fn23.Blog.Models;

namespace Caelum.Fn23.Blog.DAL
{
    public class PostDAO : BaseDAO<Post>, IPostDAO
    {
        public PostDAO(BlogContext context) : base(context)
        {
        }
    }
}
