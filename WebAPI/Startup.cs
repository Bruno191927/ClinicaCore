using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.Contratos;
using Aplicacion.Doctores;
using Dominio;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Persistencia;
using Seguridad;
using WebAPI.middlewares;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //configuramos el context como servicio
            services.AddDbContext<ClinicaContext>(opt=>{
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            //agregar servicio para IMediator
            services.AddMediatR(typeof(Consulta.Handler).Assembly);

            //configuracion del fluentValidator
            //tambien para q todos los endpoints pidan token
            services.AddControllers(opt =>{
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                opt.Filters.Add(new AuthorizeFilter(policy));
            })
            .AddFluentValidation(configure => configure.RegisterValidatorsFromAssemblyContaining<Nuevo>());

            //configuracion del core identity
            var builder = services.AddIdentityCore<Usuario>();
            var identityBuilder = new IdentityBuilder(builder.UserType,builder.Services);
            identityBuilder.AddEntityFrameworkStores<ClinicaContext>();
            identityBuilder.AddSignInManager<SignInManager<Usuario>>();

            //para generar el token
            services.AddScoped<IJwtGenerador,JwtGenerador>();

            //para usar la interfaz
            services.AddScoped<IUsuarioSesion,UsuarioSesion>();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Mi palabra secreta"));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => {
                opt.TokenValidationParameters = new TokenValidationParameters{
                    ValidateIssuerSigningKey = true, //cualquier tipo de request debe ser validado
                    IssuerSigningKey = key,
                    ValidateAudience = false, //para q cualquiera pueda hacer request
                    ValidateIssuer = false //para enviar a cualquiera
                };
            });

            //para registrar el usuario
            services.TryAddSingleton<ISystemClock,SystemClock>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //usamos nuestro middleware
            app.UseMiddleware<ErrorHandlerMiddleware>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
