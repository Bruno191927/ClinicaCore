using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Aplicacion.Contratos;
using Dominio;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;

namespace Seguridad
{
    public class JwtGenerador : IJwtGenerador
    {
        //logica del token
        public string CrearToken(Usuario usuario)
        {
            var claims = new List<Claim>{
                new Claim(JwtRegisteredClaimNames.NameId,usuario.UserName),
                //new Claim("id",usuario.Id) funciona para mandar id
            };

            //la clave
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Mi palabra secreta"));

            //credenciales
            var credenciales = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);

            var tokenDescripcion = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(30),
                SigningCredentials = credenciales
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescripcion);

            return tokenHandler.WriteToken(token);
        }
    }
}