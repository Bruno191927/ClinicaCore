using System;

namespace Dominio
{
    public class Review
    {
        public Guid ReviewId {get;set;}
        public Guid DoctorId {get;set;}
        public string Comentario {get;set;}
        public int Puntaje {get;set;}
        public string Paciente {get;set;}
        public Doctor Doctor {get;set;}
    }
}