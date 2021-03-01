using System.Collections.Generic;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Dominio;
using Persistencia;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Aplicacion.Doctores
{
    public class Consulta
    {
        public class ListaDoctores : IRequest<List<DoctorDto>>{}

        public class Handler : IRequestHandler<ListaDoctores, List<DoctorDto>>
        {
            private readonly IMapper _mapper;
            private readonly ClinicaContext _context;
            public Handler(ClinicaContext context,IMapper mapper){
                _mapper = mapper;
                _context = context;
            }

            public async Task<List<DoctorDto>> Handle(ListaDoctores request, CancellationToken cancellationToken)
            {
                var doctores = await _context.Doctor
                .Include(x => x.EspecialidadLink)
                .ThenInclude(x => x.Especialidad)
                .ToListAsync();
                var doctorDto = _mapper.Map<List<Doctor>,List<DoctorDto>>(doctores);
                return doctorDto;
            }
        }
    }
}