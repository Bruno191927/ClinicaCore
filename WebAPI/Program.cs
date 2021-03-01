using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistencia;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //antes de modificar
            //CreateHostBuilder(args).Build().Run();

            //para ejecutar el archivo de migracion
            var hostServer = CreateHostBuilder(args).Build();
            using (var ambiente = hostServer.Services.CreateScope()){
                var services = ambiente.ServiceProvider;

                try
                {
                    var userManager = services.GetRequiredService<UserManager<Usuario>>();

                    var context = services.GetRequiredService<ClinicaContext>();
                    context.Database.Migrate();

                    //jalar data prueba
                    
                    DataPrueba.InsertarData(context,userManager).Wait();
                    //usar el comando dotnet run watch en webapi
                }
                catch (Exception e)
                {
                    var logging = services.GetRequiredService<ILogger<Program>>();
                    logging.LogError(e,"Ocurrio un error al migrar");
                }

            }
            hostServer.Run();

            //entramos al proyecto webapi y ejecutamos el sgte comando
            //dotnet watch run
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
