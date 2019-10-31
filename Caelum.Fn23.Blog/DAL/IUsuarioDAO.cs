using System.Collections.Generic;
using Caelum.Fn23.Blog.Models;

namespace Caelum.Fn23.Blog.DAL
{
    public interface IUsuarioDAO
    {
        Usuario BuscarPorId(int id);
        void Incluir(Usuario usuario);
        void Alterar(Usuario usuario);
        void Excluir(Usuario usuario);
        IEnumerable<Usuario> Todos { get; }
    }
}
