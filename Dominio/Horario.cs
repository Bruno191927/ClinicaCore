using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Horario
    {
        public Guid HorarioId {get;set;}
        public string Titulo {get;set;}
        public DateTime FechaInicio {get;set;}
        public DateTime FechaFin {get;set;}
        public ICollection<DoctorHorario> DoctorLink {get;set;}
    }
}