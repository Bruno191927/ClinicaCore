using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Identity;

namespace Persistencia
{
    public class DataPrueba
    {
         public static async Task InsertarData(ClinicaContext context, UserManager<Usuario> usuarioManager){
            if(!usuarioManager.Users.Any()){
                var usuario = new Usuario{NombreCompleto = "Bruno Aguirre",UserName = "BrunoAP19",Email="bruno@gmail.com"};
                await usuarioManager.CreateAsync(usuario,"Doremifa1$");
            }
            
        }
    }
}