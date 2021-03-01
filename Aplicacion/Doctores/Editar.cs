using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.ErrorHandler;
using FluentValidation;
using MediatR;
using Persistencia;

namespace Aplicacion.Doctores
{
    public class Editar
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
                var doctor = await _context.Doctor.FindAsync(request.DoctorId);

                if(doctor == null){
                    throw new ExceptionHandler(HttpStatusCode.NotFound, new {doctor = "No se encontro doctor a editar"});
                }

                doctor.Nombres = request.Nombres ?? doctor.Nombres;
                doctor.Apellidos = request.Apellidos ?? doctor.Apellidos;
                doctor.Dni = request.Dni ?? doctor.Apellidos;
                doctor.Direccion = request.Direccion ?? doctor.Direccion;
                doctor.Celular = request.Celular ?? doctor.Celular;

                var resultado = await _context.SaveChangesAsync();
                if(resultado > 0){
                    return Unit.Value;
                }
                throw new Exception("No se pudo completar la edicion");
            }
        }
    }
}