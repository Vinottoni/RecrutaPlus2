using RecrutaPlus.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using RecrutaPlus.Web.Models;
using System.Diagnostics;
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

            //SqlConnection connection = new SqlConnection("server=localhost;User Id=root;password=123456;Persist Security Info=True;database=recrutamais2");
            //{
            //    SqlCommand command = new SqlCommand("SELECT COUNT(funcionarioId) FROM funcionarios", connection);
            //    command.Connection.Open();
            //    command.ExecuteNonQuery();
            //}

            //funcionarioSearch.TotalFuncionarios = await _funcionarioService.CountAsync(c => c.FuncionarioId);
            //funcionarioSearch.FuncionariosAtivos = await _funcionarioService.CountAsync(c => c.FuncionarioId == c.Ativo == true);
            //funcionarioSearch.FuncionariosDesativados = await _funcionarioService.CountAsync(c => c.FuncionarioId == c.Ativo == false);
            //funcionarioSearch.FuncionariosRecentes = await _funcionarioService.CountAsync(c => c.FuncionarioId);


            if (!state)
            {
                TempData[DefaultConst.TEMPDATA_FILTERSTATE] = null;
            }

            if (!string.IsNullOrWhiteSpace(TempData[DefaultConst.TEMPDATA_FILTERSTATE]?.ToString()))
            {
                funcionarioSearch = JsonSerializer.Deserialize<FuncionarioSearch>(TempData[DefaultConst.TEMPDATA_FILTERSTATE]?.ToString());
                if (funcionarioSearch.HasFilter)
                {
                    funcionarios = await _funcionarioService.GetByTakeLastRelatedAsync(funcionarioSearch.TakeLast);
                }
                else
                {
                    FuncionarioFilter filter = _mapper.Map<FuncionarioFilterViewModel, FuncionarioFilter>(funcionarioSearch?.Filter);
                    funcionarios = await _funcionarioService.GetByFilterRelatedAsync(filter);
                }

                if (state)
                {
                    TempData[DefaultConst.TEMPDATA_FILTERSTATE] = JsonSerializer.Serialize(funcionarioSearch, new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });
                }
            }
            else
            {
                if (id != null)
                {
                    Funcionario funcionario = await _funcionarioService.GetByIdRelatedAsync(id.GetValueOrDefault(-1));
                    if (funcionario != null)
                    {
                        funcionarios = new List<Funcionario>() { funcionario };
                    }
                }
                else
                {
                    funcionarios = await _funcionarioService.GetByTakeLastRelatedAsync(funcionarioSearch.TakeLast);
                }
            }

            List<FuncionarioViewModel> funcionarioViewModels = _mapper.Map<IEnumerable<Funcionario>, IEnumerable<FuncionarioViewModel>>(funcionarios).ToList();

            funcionarioSearch.Itens = funcionarioViewModels;

            _logger.LogInformation(FuncionarioConst.LOG_INDEX, User.Identity.Name ?? DefaultConst.USER_ANONYMOUS, DateTime.Now);

            return View(funcionarioSearch);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}