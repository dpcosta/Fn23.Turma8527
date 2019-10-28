using Microsoft.AspNetCore.Hosting;

namespace Caelum.Fn23.PrimeiraWebApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //hospedeiro web (irá receber as chamadas)
            IWebHost host = new WebHostBuilder()
                .UseKestrel() //implementação do servidor web (quem de fato é responsável) 
                .UseStartup<Startup>() //configuração
                .Build(); //método que instancia o objeto q implementa IWebHost

            host.Run(); //execução do servidor web
        }
    }
}
