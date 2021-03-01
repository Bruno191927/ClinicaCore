using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Especialidad
    {
        public Guid EspecialidadId {get;set;}
        public string Titulo {get;set;}
        public string Descripcion {get;set;}
        public DateTime FechaPublicacion {get;set;}
        public ICollection<DoctorEspecialidad> DoctorLink {get;set;}
    }
}