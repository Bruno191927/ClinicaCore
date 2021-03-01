using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.ErrorHandler;
using MediatR;
using Persistencia;

namespace Aplicacion.Doctores
{
    public class Eliminar
    {
        public class Ejecuta : IRequest {
            public int Id {get;set;}
        }

        public class Handler : IRequestHandler<Ejecuta>
        {
            private readonly ClinicaContext _context;
            public Handler(ClinicaContext context){
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var doctor = await _context.Doctor.FindAsync(request.Id);
                if(doctor == null){
                    throw new ExceptionHandler(HttpStatusCode.NotFound,new {doctor = "No se encontro al doctor"});
                }
                _context.Remove(doctor);

                var resultado = await _context.SaveChangesAsync();
                if(resultado > 0){
                    return Unit.Value;
                }

                throw new Exception("No se pudo guardar los cambios");
            }
        }
    }
}