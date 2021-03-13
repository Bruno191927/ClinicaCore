using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Horarios
{
    public class Consulta
    {
        public class ListaHorario : IRequest<List<HorarioDto>>{}

        public class Handler : IRequestHandler<ListaHorario, List<HorarioDto>>
        {
            private readonly ClinicaContext _context;
            private readonly IMapper _mapper;
            public Handler(ClinicaContext context,IMapper mapper){
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<HorarioDto>> Handle(ListaHorario request, CancellationToken cancellationToken)
            {
                var horarios = await _context.Horario.ToListAsync();
                var horarioDto = _mapper.Map<List<Horario>,List<HorarioDto>>(horarios);
                return horarioDto;
            }
        }

    }
}