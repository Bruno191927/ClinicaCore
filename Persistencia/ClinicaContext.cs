using Dominio;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistencia
{
    public class ClinicaContext : IdentityDbContext<Usuario> //antes heredaba de DbContext
    {
        public ClinicaContext(DbContextOptions options) : base(options){

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){

            //para agregar el archivo de migración
            base.OnModelCreating(modelBuilder);

            //con el comando
            //dotnet ef migrations add IdentityCoreInitial -p Persistencia/ -s WebAPI
            //dotnet ef migrations add {NombreMigracion} -p Persistencia/ -s WebAPI/
            //creas los archivos de migracion

            modelBuilder.Entity<DoctorEspecialidad>().HasKey(ci => new{ci.DoctorId,ci.EspecialidadId});
            modelBuilder.Entity<DoctorHorario>().HasKey(ci => new{ci.DoctorId,ci.HorarioId});
        }

        //convertir en entidades

        public DbSet<Doctor> Doctor {get;set;}
        public DbSet<Especialidad> Especialidad {get;set;}
        public DbSet<Horario> Horario {get;set;}
        public DbSet<Review> Review {get;set;}
        public DbSet<DoctorEspecialidad> DoctorEspecialidad {get;set;}
        public DbSet<DoctorHorario> DoctorHorario {get;set;}
        public DbSet<Usuario> Usuario {get;set;}
        public DbSet<Cita> Cita {get;set;}
        public DbSet<Precio> Precio {get;set;}
    }
}