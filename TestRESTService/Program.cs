using Microsoft.AspNetCore.Hosting;

namespace TestRESTService
{
    class Program
    {
        static void Main(string[] args)
        {
            var hostBuilder = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();

            hostBuilder.Run();
        }
    }
}
