using AutoMapper;
using Juridico.Domain.Cliente.Entities;
using Juridico.Domain.Core.Entities;
using Juridico.Domain.Ficha.Entities;
using Juridico.DTL.Cliente;
using Juridico.DTL.Core;
using Juridico.DTL.Ficha;

namespace Juridico.Application.Mappers
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<ClienteEntity, ClienteDTO>().ReverseMap();
            CreateMap<ClienteArquivoEntity, ClienteArquivoDTO>().ReverseMap();
            CreateMap<FichaEntity, FichaDTO>().ReverseMap();
            CreateMap<FichaArquivoEntity, FichaArquivoDTO>().ReverseMap();
            CreateMap<EstadoCivilEntity, EstadoCivilDTO>().ReverseMap();
        }
    }
}
