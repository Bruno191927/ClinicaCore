using System;

namespace Aplicacion.Horarios
{
    public class HorarioDto
    {
        public Guid HorarioId {get;set;}
        public string Titulo {get;set;}
        public DateTime? FechaInicio {get;set;}
        public DateTime? FechaFin {get;set;}
    }
}