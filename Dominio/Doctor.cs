using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Doctor
    {
        public Guid DoctorId {get;set;}
        public string Nombres {get;set;}
        public string Apellidos {get;set;}
        public string Dni {get;set;}
        public string Direccion {get;set;}
        public string Celular {get;set;}
        public byte[] Foto {get;set;}
        public ICollection<Review> ReviewLista {get;set;}
        public ICollection<DoctorEspecialidad> EspecialidadLink {get;set;}
        public ICollection<DoctorHorario> HorarioLink {get;set;}
    }
}