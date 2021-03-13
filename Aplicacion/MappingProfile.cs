using System.Linq;
using Aplicacion.Doctores;
using Aplicacion.Especialidades;
using Aplicacion.Horarios;
using AutoMapper;
using Dominio;

namespace Aplicacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile(){
            CreateMap<Doctor,DoctorDto>()
            .ForMember(x => x.Especialidades,y=>y.MapFrom(z=>z.EspecialidadLink.Select(a => a.Especialidad).ToList()));
            CreateMap<Especialidad,SimpleEspecialidadDto>();
            CreateMap<DoctorEspecialidad,DoctorEspecialidadDto>();
            CreateMap<Especialidad,EspecialidadDto>()
            .ForMember(x => x.Doctores,y =>y.MapFrom(z => z.DoctorLink.Select(a => a.Doctor).ToList()));
            CreateMap<Doctor,SimpleDoctorDto>();
            CreateMap<Horario,HorarioDto>();
        }
    }
}