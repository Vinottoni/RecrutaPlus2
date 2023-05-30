using AutoMapper;
using RecrutaPlus.Application.ViewModels;
using RecrutaPlus.Domain.Constants;
using RecrutaPlus.Domain.Entities;
using RecrutaPlus.Domain.Interfaces;
using RecrutaPlus.Domain.Interfaces.Services;
using RecrutaPlus.Domain.Resources;
using RecrutaPlus.Domain.Services;
using RecrutaPlus.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace RecrutaPlus.Web.Controllers
{
    public class RegisterController : BaseController
    {
        private readonly IFuncionarioService _funcionarioService;

        public RegisterController(
            IMapper mapper, 
            IAppLogger logger, 
            IFuncionarioService funcionarioService) : base(logger, mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _funcionarioService = funcionarioService;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation(FuncionarioConst.LOG_INDEX, GetUserName(), DateTime.Now);

            FuncionarioViewModel funcionarioViewModel = await Task.Run(() => new FuncionarioViewModel());

            return View(funcionarioViewModel);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.SelectListCargos = await Task.Run(() => SelectListCargos());

            _logger.LogInformation(FuncionarioConst.LOG_CREATE, User.Identity.Name ?? DefaultConst.USER_ANONYMOUS, DateTime.Now);

            FuncionarioViewModel funcionarioViewModel = await Task.Run(() => new FuncionarioViewModel());

            return View(funcionarioViewModel);
        }

        //[Authorize(Policy = AuthorizationPolicyConst.REGISTER_CREATE)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FuncionarioViewModel funcionarioViewModel)
        {
            ViewBag.SelectListCargos = await Task.Run(() => SelectListCargos());

            //AutoMapper
            var funcionario = _mapper.Map<FuncionarioViewModel, Funcionario>(funcionarioViewModel);

            funcionario.Cadastro = DateTime.Now;
            funcionario.CadastradoPor = User.Identity.Name ?? DefaultConst.USER_ANONYMOUS;
            funcionario.Edicao = DateTime.Now;
            funcionario.EditadoPor = User.Identity.Name ?? DefaultConst.USER_ANONYMOUS;
            funcionario.GuidStamp = Guid.NewGuid();

            ServiceResult serviceResult = _funcionarioService.Add(funcionario);

            //Validation
            if (serviceResult.HasErrors)
            {

                serviceResult.ToModelStateDictionary(ModelState);

                return View(funcionarioViewModel);
            }

            _ = await _funcionarioService.SaveChangesAsync();

            SuccessMessage = FuncionarioResource.MSG_SAVED_SUCCESSFULLY;

            _logger.LogInformation(FuncionarioConst.LOG_CREATE, User.Identity.Name ?? DefaultConst.USER_ANONYMOUS, DateTime.Now);

            return RedirectToAction(nameof(Index), new { id = funcionario?.FuncionarioId });
        }

        #region SelectList

        private List<SelectListItem> SelectListCargos()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            IEnumerable<Funcionario> funcionarios = _funcionarioService.GetAllAsync().GetAwaiter().GetResult();

            selectListItems.Add(new SelectListItem(DefaultResource.MSG_SELECIONE, string.Empty, true));

            //foreach (var item in funcionarios.OrderBy(o => o.cargo))
            //{
            //    selectListItems.Add(new SelectListItem(text: item.Nome, value: item.BancoId.ToString()));
            //}

            return selectListItems;
        }

        #endregion
    }
}