using AutoMapper;
using RecrutaPlus.Application.Filters;
using RecrutaPlus.Application.ViewModels;
using RecrutaPlus.Domain.Entities;

namespace RecrutaPlus.Application.AutoMapper
{
    public class AutoMapperMappingProfile : Profile
    {
        public AutoMapperMappingProfile() 
        {
            CreateMap<Funcionario, FuncionarioViewModel>().ReverseMap();
            CreateMap<Login, LoginViewModel>().ReverseMap();
            CreateMap<Cargo, CargoViewModel>().ReverseMap();
            CreateMap<Ferias, FeriasViewModel>().ReverseMap();

            //ParamFilterViewModel
            CreateMap<FuncionarioFilter, FuncionarioFilterViewModel>().ReverseMap();
            CreateMap<LoginFilter, LoginFilterViewModel>().ReverseMap();
            CreateMap<CargoFilter, CargoFilterViewModel>().ReverseMap();
            CreateMap<FeriasFilter, FeriasFilterViewModel>().ReverseMap();
        }
    }
}
