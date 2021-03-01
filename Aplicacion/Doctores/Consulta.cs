using System.Collections.Generic;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Dominio;
using Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Doctores
{
    public class Consulta
    {
        public class ListaDoctores : IRequest<List<Doctor>>{}

        public class Handler : IRequestHandler<ListaDoctores, List<Doctor>>
        {
            private readonly ClinicaContext _context;
            public Handler(ClinicaContext context){
                _context = context;
            }

            public async Task<List<Doctor>> Handle(ListaDoctores request, CancellationToken cancellationToken)
            {
                var cursos = await _context.Doctor.ToListAsync();
                return cursos;
            }
        }
    }
}