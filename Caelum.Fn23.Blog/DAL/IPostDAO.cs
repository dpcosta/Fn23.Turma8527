using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caelum.Fn23.Blog.Models;

namespace Caelum.Fn23.Blog.DAL
{
    public interface IPostDAO
    {
        Post BuscarPorId(int id);
        void Incluir(Post post);
        void Alterar(Post post);
        void Excluir(Post post);
        IEnumerable<Post> Todos { get; }
    }
}
