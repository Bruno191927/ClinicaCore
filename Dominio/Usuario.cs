using Microsoft.AspNetCore.Identity;

namespace Dominio
{
    public class Usuario : IdentityUser //para usar el identitycore
    {
        public string NombreCompleto {get;set;}
    }
}