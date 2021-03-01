using System;
using System.Collections.Generic;
using Aplicacion.Especialidades;

namespace Aplicacion.Doctores
{
    public class DoctorDto
    {
        public Guid DoctorId {get;set;}
        public string Nombres {get;set;}
        public string Apellidos {get;set;}
        public string Dni {get;set;}
        public string Direccion {get;set;}
        public string Celular {get;set;}
        public byte[] Foto {get;set;}
        public ICollection<SimpleEspecialidadDto> Especialidades {get;set;}
    }
}