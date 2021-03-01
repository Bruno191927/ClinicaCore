using System;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using FluentValidation;
using MediatR;
using Persistencia;

namespace Aplicacion.Especialidades
{
    public class Nuevo
    {
        public class Ejecuta : IRequest{
            public string Titulo {get;set;}
            public string Descripcion {get;set;}
            public DateTime? FechaPublicacion {get;set;}
        }
        public class EjecutaValidation : AbstractValidator<Ejecuta>{
            public EjecutaValidation(){
                RuleFor(x => x.FechaPublicacion).NotEmpty();
                RuleFor(x=>x.Titulo).NotEmpty();
                RuleFor(x=>x.Descripcion).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Ejecuta>
        {
            private readonly ClinicaContext _context;
            public Handler(ClinicaContext context){
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var especialidad = new Especialidad{
                    EspecialidadId=Guid.NewGuid(),
                    Descripcion = request.Descripcion,
                    Titulo = request.Titulo,
                    FechaPublicacion = request.FechaPublicacion
                };

                _context.Especialidad.Add(especialidad);
                var valor = await _context.SaveChangesAsync();

                if(valor > 0){
                    return Unit.Value;
                }

                throw new Exception("No se pudo insertar la Especialidad");
            }
        }
    }
}