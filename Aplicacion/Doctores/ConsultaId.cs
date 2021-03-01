using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Persistencia;

namespace Aplicacion.Doctores
{
    public class ConsultaId
    {
        public class CursoUnico : IRequest<Doctor>{
            public int Id {get;set;}
        }

        public class Handler : IRequestHandler<CursoUnico, Doctor>
        {
            private readonly ClinicaContext _context;
            public Handler(ClinicaContext context){
                _context = context;
            }

            public async Task<Doctor> Handle(CursoUnico request, CancellationToken cancellationToken)
            {
                var doctor = await _context.Doctor.FindAsync(request.Id);
                return doctor;
            }
        }
    }
}