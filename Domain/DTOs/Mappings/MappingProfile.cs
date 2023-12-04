using AutoMapper;
using Domain.Model;

namespace Domain.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Funcionario, FuncionarioDto>().ReverseMap();
            CreateMap<Cargo, CargosDto>().ReverseMap();
            CreateMap<FuncionarioCargo, FuncionarioCargoDto>().ReverseMap();
        }
    }
}
