using System;

namespace Aplicacion.Doctores
{
    public class SimpleEspecialidadDto
    {
        public Guid EspecialidadId {get;set;}
        public string Titulo {get;set;}
        public string Descripcion {get;set;}
        public DateTime? FechaPublicacion {get;set;}
    }
}