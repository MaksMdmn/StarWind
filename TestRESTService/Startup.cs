using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Reflection;
using TestCommon;
using TestRESTService.Repositories;
using TestRESTService.Repositories.Interfaces;

namespace TestRESTService
{
    //Build consoleApp cmd: dotnet publish -c Release -r win10-x64
    public class Startup
    {
        public void Configure(IApplicationBuilder app, ILoggerFactory log)
        {
            //Default route
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}"
                    );
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //Find plugin library in core folder
            string serviceFullName = Directory.GetCurrentDirectory() + @"\ServicePlugin";

            //Build an assembly, then add it as service:
            // As TestCommon is statically linked to the project, we could use it as abstract service type
            // Because of [Export] of implementation of IPlugin in ServicePlugin.dll, so we can use it as implementation type of service
            Assembly serviceAssembly = Assembly.LoadFile(serviceFullName);
            var serviceType = typeof(IPlugin);
            var serviceImpl = serviceAssembly.GetExportedTypes()[0];

            //Mvc is needed to work with conroller
            services.AddMvc();
            //Service from assembly above
            services.AddSingleton(serviceType, serviceImpl);
            //DI for repository
            services.AddScoped<IClientRepository, ClientRepository>();
            //Logging to console and its configuration
            services.AddLogging(configure => configure.AddConsole())
                .Configure<LoggerFilterOptions>(options => options.MinLevel = LogLevel.Information);
        }
    }
}
