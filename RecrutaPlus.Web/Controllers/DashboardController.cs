using RecrutaPlus.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using RecrutaPlus.Application.Searches;
using RecrutaPlus.Application.Filters;
using RecrutaPlus.Domain.Constants;
using RecrutaPlus.Domain.Entities;
using System.Text.Json.Serialization;
using System.Text.Json;
using AutoMapper;
using RecrutaPlus.Domain.Interfaces.Services;
using RecrutaPlus.Domain.Interfaces;
using Microsoft.Data.SqlClient;

namespace RecrutaPlus.Web.Controllers
{
    public class DashboardController : BaseController
    {
        private readonly IFuncionarioService _funcionarioService;

        public DashboardController(
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
            FuncionarioSearch funcionarioSearch = new FuncionarioSearch();
            IEnumerable<Funcionario> funcionarios = null;

            DashboardViewModel dashboardViewModel = new DashboardViewModel();

            dashboardViewModel.TotalFuncionarios = await _funcionarioService.CountAsync(c => c.FuncionarioId > 0);
            dashboardViewModel.FuncionariosAtivos = await _funcionarioService.CountAsync(c => c.Ativo == true);
            dashboardViewModel.FuncionariosDesativados = await _funcionarioService.CountAsync(c => c.Ativo == false);
            dashboardViewModel.FuncionariosRecentes = await _funcionarioService.CountAsync(c => c.Edicao >= DateTime.Now.AddDays(-30));

            funcionarios = await _funcionarioService.GetByTakeLastRelatedAsync(funcionarioSearch.TakeLast);

            List<FuncionarioViewModel> funcionarioViewModels = _mapper.Map<IEnumerable<Funcionario>, IEnumerable<FuncionarioViewModel>>(funcionarios).ToList();

            funcionarioSearch.Itens = funcionarioViewModels;
            funcionarioSearch.DashboardViewModel = dashboardViewModel;

            _logger.LogInformation(FuncionarioConst.LOG_INDEX, User.Identity.Name ?? DefaultConst.USER_ANONYMOUS, DateTime.Now);

            return View(funcionarioSearch);
        }
    }
}