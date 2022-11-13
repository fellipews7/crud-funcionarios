using TesteLabs.Domain;
using AutoMapper;

namespace TesteLabs.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap <Cidades, CidadesDto>().ReverseMap();
            CreateMap <Estados, EstadosDto>().ReverseMap();
            CreateMap <Funcionarios, FuncionariosDto>().ReverseMap();
            CreateMap <FuncionariosEnderecos, FuncionariosEnderecosDto>().ReverseMap();
            CreateMap <Paises, PaisesDto>().ReverseMap();

        }
    }
}
