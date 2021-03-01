using System;

namespace Dominio
{
    public class Cita
    {
        public Guid CitaId {get;set;}
        public string Titutlo {get;set;}
        public string Descripcion {get;set;}
        public DateTime fechaCita {get;set;}
        public Guid DoctorId {get;set;}
        public Doctor Doctor {get;set;}
    }
}