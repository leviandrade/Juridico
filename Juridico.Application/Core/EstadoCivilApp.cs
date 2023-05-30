using AutoMapper;
using Juridico.Application.Core.Interfaces;
using Juridico.Domain.Core.Repositories;
using Juridico.DTL.Core;

namespace Juridico.Application.Core
{
    public sealed class EstadoCivilApp : IEstadoCivilApp
    {
        private readonly IEstadoCivilRepository _estadoCivilRepository;
        private readonly IMapper _mapper;
        public EstadoCivilApp(IEstadoCivilRepository estadoCivilRepository, IMapper mapper)
        {
            _estadoCivilRepository = estadoCivilRepository;
            _mapper = mapper;
        }

        public async Task<List<EstadoCivilDTO>> Listar()
        {
            var lstEstadoCivil = await _estadoCivilRepository.Listar();
            return _mapper.Map<List<EstadoCivilDTO>>(lstEstadoCivil);
        }
    }
}
