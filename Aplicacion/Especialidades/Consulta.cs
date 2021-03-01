using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Especialidades
{
    public class Consulta
    {
        public class ListaEspecialidad : IRequest<List<Especialidad>>{}
        public class Handler : IRequestHandler<ListaEspecialidad, List<Especialidad>>{
            private readonly ClinicaContext _context;
            public Handler(ClinicaContext context){
                _context = context;
            }
            public async Task<List<Especialidad>> Handle(ListaEspecialidad request, CancellationToken cancellationToken)
            {
                var especialidades = await _context.Especialidad.ToListAsync();
                return especialidades;
            }
        }
    }
}