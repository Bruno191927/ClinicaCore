using System;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using FluentValidation;
using MediatR;
using Persistencia;

namespace Aplicacion.Doctores
{
    public class Nuevo
    {
        public class Ejecuta : IRequest{
            public int DoctorId {get;set;}
            public string Nombres {get;set;}
            public string Apellidos {get;set;}
            public string Dni {get;set;}
            public string Direccion {get;set;}
            public string Celular {get;set;}
        }

        public class EjecutaValidation : AbstractValidator<Ejecuta>{
            public EjecutaValidation(){
                RuleFor(x => x.Nombres).NotEmpty();
                RuleFor(x => x.Apellidos).NotEmpty();
                RuleFor(x => x.Dni).NotEmpty();
                RuleFor(x => x.Direccion).NotEmpty();
                RuleFor(x => x.Celular).NotEmpty();
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
                var doctor = new Doctor{
                    Nombres = request.Nombres,
                    Apellidos = request.Apellidos,
                    Dni = request.Dni,
                    Direccion = request.Direccion,
                    Celular = request.Celular
                };

                _context.Doctor.Add(doctor);

                var valor = await _context.SaveChangesAsync();
                if(valor > 0){
                    return Unit.Value;
                }

                throw new Exception("No se pudo insertar el doctor");
            }
        }
    }
}