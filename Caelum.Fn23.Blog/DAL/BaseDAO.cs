using Caelum.Fn23.Blog.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caelum.Fn23.Blog.DAL
{
    public class BaseDAO<T> where T: class
    {
        protected BlogContext context;

        public BaseDAO(BlogContext context)
        {
            this.context = context;
        }

        public virtual T BuscarPorId(int id)
        {
            return context.Set<T>().Find(id);
        }
        public virtual void Incluir(T obj) 
        {
            context.Set<T>().Add(obj);
            context.SaveChanges();
        }

        public virtual void Alterar(T obj)
        {
            context.Set<T>().Update(obj);
            context.SaveChanges();
        }

        public virtual void Excluir(T obj)
        {
            context.Set<T>().Remove(obj);
            context.SaveChanges();
        }

        public virtual IEnumerable<T> Todos => context.Set<T>();
    }
}
