using AutoMapper;
using Safety.Application.Filters;
using Safety.Application.ViewModels;
using Safety.Domain.Entities;

namespace Safety.Application.AutoMapper
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
