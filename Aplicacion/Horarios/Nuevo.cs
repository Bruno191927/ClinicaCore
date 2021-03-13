using System;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using FluentValidation;
using MediatR;
using Persistencia;

namespace Aplicacion.Horarios
{
    public class Nuevo
    {
        public class Ejecuta : IRequest{
            public string Titulo {get;set;}
            public DateTime? FechaInicio {get;set;}
            public DateTime? FechaFin {get;set;}
        }

        public class EjecutaValidator : AbstractValidator<Ejecuta>{
            public EjecutaValidator(){
                RuleFor(x => x.Titulo).NotEmpty();
                RuleFor(x => x.FechaInicio).NotEmpty();
                RuleFor(x => x.FechaFin).NotEmpty();
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
                var horario = new Horario{
                    HorarioId = Guid.NewGuid(),
                    Titulo = request.Titulo,
                    FechaInicio = request.FechaInicio,
                    FechaFin = request.FechaFin
                };

                _context.Horario.Add(horario);

                var resultado = await _context.SaveChangesAsync();

                if(resultado > 0){
                    return Unit.Value;
                }

                throw new Exception("No se pudo insertar el Horario");
            }
        }
    }
}