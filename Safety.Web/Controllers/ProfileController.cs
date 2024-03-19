using Safety.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Safety.Domain.Interfaces.Services;
using AutoMapper;
using Safety.Domain.Interfaces;
using Safety.Domain.Constants;
using Safety.Domain.Entities;
using Safety.Application.Filters;
using Safety.Application.Searches;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Safety.Web.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly IFuncionarioService _funcionarioService;

        public ProfileController(
            IMapper mapper,
            IAppLogger logger,
            IFuncionarioService funcionarioService) : base(logger, mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _funcionarioService = funcionarioService;
        }

        public async Task<IActionResult> Index(int? id, bool state = false)
        {
            //FuncionarioSearch funcionarioSearch = new FuncionarioSearch();
            //IEnumerable<Funcionario> funcionarios = null;

            //if (!state)
            //{
            //    TempData[DefaultConst.TEMPDATA_FILTERSTATE] = null;
            //}

            //if (!string.IsNullOrWhiteSpace(TempData[DefaultConst.TEMPDATA_FILTERSTATE]?.ToString()))
            //{
            //    funcionarioSearch = JsonSerializer.Deserialize<FuncionarioSearch>(TempData[DefaultConst.TEMPDATA_FILTERSTATE]?.ToString());
            //    if (funcionarioSearch.HasFilter)
            //    {
            //        funcionarios = await _funcionarioService.GetByTakeLastRelatedAsync(funcionarioSearch.TakeLast);
            //    }
            //    else
            //    {
            //        FuncionarioFilter filter = _mapper.Map<FuncionarioFilterViewModel, FuncionarioFilter>(funcionarioSearch?.Filter);
            //        funcionarios = await _funcionarioService.GetByFilterRelatedAsync(filter);
            //    }

            //    if (state)
            //    {
            //        TempData[DefaultConst.TEMPDATA_FILTERSTATE] = JsonSerializer.Serialize(funcionarioSearch, new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });
            //    }
            //}
            //else
            //{
            //    if (id != null)
            //    {
            //        Funcionario funcionario = await _funcionarioService.GetByIdRelatedAsync(id.GetValueOrDefault(-1));
            //        if (funcionario != null)
            //        {
            //            funcionarios = new List<Funcionario>() { funcionario };
            //        }
            //    }
            //    else
            //    {
            //        funcionarios = await _funcionarioService.GetByTakeLastRelatedAsync(funcionarioSearch.TakeLast);
            //    }
            //}

            //List<FuncionarioViewModel> funcionarioViewModels = _mapper.Map<IEnumerable<Funcionario>, IEnumerable<FuncionarioViewModel>>(funcionarios).ToList();

            //funcionarioSearch.Itens = funcionarioViewModels;

            //_logger.LogInformation(FuncionarioConst.LOG_INDEX, User.Identity.Name ?? DefaultConst.USER_ANONYMOUS, DateTime.Now);

            //return View(funcionarioSearch);

            _logger.LogInformation(FuncionarioConst.LOG_CREATE, User.Identity.Name ?? DefaultConst.USER_ANONYMOUS, DateTime.Now);

            FuncionarioViewModel funcionarioViewModel = await Task.Run(() => new FuncionarioViewModel());

            return View(funcionarioViewModel);
        }
    }
}