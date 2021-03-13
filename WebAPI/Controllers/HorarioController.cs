using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.Horarios;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class HorarioController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<HorarioDto>>> GetHorarios(){
            return await Mediator.Send(new Consulta.ListaHorario());
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> InsertarHorario(Nuevo.Ejecuta parametros){
            return await Mediator.Send(parametros);
        }
    }
}