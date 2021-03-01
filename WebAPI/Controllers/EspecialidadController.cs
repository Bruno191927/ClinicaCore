using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.Especialidades;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<EspecialidadDto>>> Get(){
            return await Mediator.Send(new ConsultaEspecialidad.ListaEspecialidades());
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data){
            return await Mediator.Send(data);
        }
    }
}