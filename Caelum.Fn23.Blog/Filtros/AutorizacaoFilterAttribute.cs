using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Caelum.Fn23.Blog.Filtros
{
    public class AutorizacaoFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string usuario = context.HttpContext.Session.GetString("usuario");
            if (usuario == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    area = "",
                    controller = "Usuario",
                    action = "Login"
                }));
            }
        }
    }
}
