using System;

namespace Aplicacion.Especialidades
{
    public class SimpleDoctorDto
    {
        public Guid DoctorId {get;set;}
        public string Nombres {get;set;}
        public string Apellidos {get;set;}
        public string Dni {get;set;}
        public string Direccion {get;set;}
        public string Celular {get;set;}
        public byte[] Foto {get;set;}
    }
}