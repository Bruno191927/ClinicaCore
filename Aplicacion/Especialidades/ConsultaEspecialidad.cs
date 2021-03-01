using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Especialidades
{
    public class ConsultaEspecialidad
    {
        public class ListaEspecialidades : IRequest<List<EspecialidadDto>>{}
        public class Handler : IRequestHandler<ListaEspecialidades, List<EspecialidadDto>>
        {
            private readonly ClinicaContext _context;
            private readonly IMapper _mapper;
            public Handler(ClinicaContext context, IMapper mapper){
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<EspecialidadDto>> Handle(ListaEspecialidades request, CancellationToken cancellationToken)
            {
                var especialidades = await _context.Especialidad
                .Include(x => x.DoctorLink)
                .ThenInclude(x => x.Doctor)
                .ToListAsync();
                var especialidadDto = _mapper.Map<List<Especialidad>,List<EspecialidadDto>>(especialidades);
                return especialidadDto;
            }
        }
    }
}