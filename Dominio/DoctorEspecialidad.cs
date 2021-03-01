using System;

namespace Dominio
{
    public class DoctorEspecialidad
    {
        public Guid DoctorId {get;set;}
        public Doctor Doctor {get;set;}
        public Guid EspecialidadId {get;set;}
        public Especialidad Especialidad {get;set;}
    }
}