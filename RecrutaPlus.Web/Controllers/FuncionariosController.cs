using RecrutaPlus.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using RecrutaPlus.Domain.Interfaces.Services;
using AutoMapper;
using RecrutaPlus.Domain.Interfaces;
using RecrutaPlus.Domain.Entities;
using RecrutaPlus.Domain.Constants;
using System.Text.Json.Serialization;
using System.Text.Json;
using RecrutaPlus.Application.Searches;
using RecrutaPlus.Application.Filters;
using RecrutaPlus.Domain.Services;
using RecrutaPlus.Domain.Resources;
using RecrutaPlus.Web.Extensions;

namespace RecrutaPlus.Web.Controllers
{
    public class FuncionariosController : BaseController
    {
        private readonly IFuncionarioService _funcionarioService;

        public FuncionariosController(
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(FuncionarioSearch funcionarioSearch)
        {
            IEnumerable<Funcionario> funcionarios;

            if (funcionarioSearch.HasFilter)
            {
                funcionarios = await _funcionarioService.GetByTakeLastRelatedAsync(funcionarioSearch.TakeLast);
            }
            else
            {
                FuncionarioFilter filter = _mapper.Map<FuncionarioFilterViewModel, FuncionarioFilter>(funcionarioSearch?.Filter);
                funcionarios = await _funcionarioService.GetByFilterRelatedAsync(filter);
            }

            List<FuncionarioViewModel> funcionarioViewModels = _mapper.Map<IEnumerable<Funcionario>, IEnumerable<FuncionarioViewModel>>(funcionarios).ToList();

            funcionarioSearch.Itens = funcionarioViewModels;

            TempData[DefaultConst.TEMPDATA_FILTERSTATE] = JsonSerializer.Serialize(funcionarioSearch, new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });

            _logger.LogInformation(FuncionarioConst.LOG_INDEX, User.Identity.Name ?? DefaultConst.USER_ANONYMOUS, DateTime.Now);

            return View(funcionarioSearch);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Funcionario funcionario = await _funcionarioService.GetByIdRelatedAsync(id.GetValueOrDefault(-1));

            if (funcionario == null)
            {
                return NotFound();
            }

            //AutoMapper
            var funcionarioViewModel = _mapper.Map<Funcionario, FuncionarioViewModel>(funcionario);

            _logger.LogInformation(FuncionarioConst.LOG_DETAILS, User.Identity.Name ?? DefaultConst.USER_ANONYMOUS, DateTime.Now);

            return View(funcionarioViewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Funcionario funcionario = await _funcionarioService.GetByIdRelatedAsync(id.GetValueOrDefault(-1));

            if (funcionario == null)
            {
                return NotFound();
            }

            //AutoMapperc
            var funcionarioViewModel = _mapper.Map<Funcionario, FuncionarioViewModel>(funcionario);

            _logger.LogInformation(FuncionarioConst.LOG_EDIT, User.Identity.Name ?? DefaultConst.USER_ANONYMOUS, DateTime.Now);

            return View(funcionarioViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FuncionarioViewModel funcionarioViewModel)
        {
            if (id != funcionarioViewModel.FuncionarioId)
            {
                return NotFound();
            }

            //AutoMapper
            var funcionario = _mapper.Map<FuncionarioViewModel, Funcionario>(funcionarioViewModel);

            funcionario.Edicao = DateTime.Now;
            funcionario.EditadoPor = User.Identity.Name ?? DefaultConst.USER_ANONYMOUS;

            ServiceResult serviceResult = _funcionarioService.Update(funcionario);

            //Validation
            if (serviceResult.HasErrors)
            {
                //ViewBag.SelectListColaboradores = await Task.Run(() => SelectListColaboradores());

                serviceResult.ToModelStateDictionary(ModelState);
                return View(funcionarioViewModel);
            }

            _ = await _funcionarioService.SaveChangesAsync();

            SuccessMessage = DefaultResource.MSG_UPDATE_SUCCESSFULLY;

            _logger.LogInformation(FuncionarioConst.LOG_EDIT, User.Identity.Name ?? DefaultConst.USER_ANONYMOUS, DateTime.Now);

            return RedirectToAction(nameof(Index), new { id = funcionario?.FuncionarioId });
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Funcionario funcionario = await _funcionarioService.GetByIdRelatedAsync(id.GetValueOrDefault(-1));

            if (funcionario == null)
            {
                return NotFound();
            }
            //AutoMapper
            var funcionarioViewModel = _mapper.Map<Funcionario, FuncionarioViewModel>(funcionario);

            _logger.LogInformation(FuncionarioConst.LOG_DELETE, User.Identity.Name ?? DefaultConst.USER_ANONYMOUS, DateTime.Now);

            return View(funcionarioViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionario = await _funcionarioService.FindByIdAsync(id);
            ServiceResult serviceResult = _funcionarioService.Delete(funcionario);

            //Validation
            if (serviceResult.HasErrors)
            {
                serviceResult.ToModelStateDictionary(ModelState);
                ErrorMessage = serviceResult.ToHtml();
                return RedirectToAction(nameof(Delete), new { id = funcionario?.FuncionarioId });
            }

            _ = await _funcionarioService.SaveChangesAsync();

            SuccessMessage = DefaultResource.MSG_SAVED_SUCCESSFULLY;

            _logger.LogInformation(FuncionarioConst.LOG_DELETE, User.Identity.Name ?? DefaultConst.USER_ANONYMOUS, DateTime.Now);

            return RedirectToAction(nameof(Index));
        }

    }
}