using System;

namespace Dominio
{
    public class DoctorHorario
    {
        public Guid DoctorId {get;set;}
        public Doctor Doctor {get;set;}
        public Guid HorarioId {get;set;}
        public Horario Horario {get;set;}
    }
}