using System;
using System.Collections.Generic;

namespace Aplicacion.Especialidades
{
    public class EspecialidadDto
    {
        public Guid EspecialidadId {get;set;}
        public string Titulo {get;set;}
        public string Descripcion {get;set;}
        public DateTime? FechaPublicacion {get;set;}
        public ICollection<SimpleDoctorDto> Doctores {get;set;}
    }
}