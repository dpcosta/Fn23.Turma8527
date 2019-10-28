using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Caelum.Fn23.PrimeiraWebApp
{
    class Startup
    {
        int contador;

        public Task RespondeAloMundo(HttpContext context)
        {
            //dêem uma olhada nas propriedades de context.Request...
            string resposta = $"Oi, mundo AspNet Core!!\nProtocolo: {context.Request.Protocol} \nServidor: {context.Request.Host} \nMétodo:{context.Request.Method}  \nCaminho: {context.Request.Path} \nQuery: {context.Request.QueryString}\nFoi chamada {contador} vezes";
            
            //também podemos mexer em outros campos da resposta:
            context.Response.StatusCode = 201;

            //mas como ver se funcionou? Ferramentas do Desenvolvedor (F12)
            return context.Response.WriteAsync(resposta);
        }

        private Task ContaRequisicao(HttpContext context, Func<Task> proximoEstagio)
        {
            contador++;
            return proximoEstagio.Invoke();
        }

        private void TrataModuloCompras(IApplicationBuilder app)
        {
            app.Run(ctx => ctx.Response.WriteAsync("Chegou no módulo de compras"));
        }

        public void Configure(IApplicationBuilder app)
        {

            app.UseMvc();
            //amarrar requisição => resposta
            app.Map("/compras", TrataModuloCompras);
            app.Use(ContaRequisicao);
            app.Run(RespondeAloMundo);

            //URL: protocolo://servidor:porta/caminho na aplicação

            //característica do AspNetCore >> pipeline de requisição, composto por estágios que são configurados/amarrados aqui através dos métodos Use(), Run() e Map()

            //como responder coisas diferentes? tratar o caminho (Path)! Método Map() tb

            //roteamento: convenção/regra para interpretar o caminho => segmentos
            
            //problema é que se continuarmos assim iremos deixar a classe de configuração muito cheia
            //separar responsabilidades! Classes respon
        }
    }
}
