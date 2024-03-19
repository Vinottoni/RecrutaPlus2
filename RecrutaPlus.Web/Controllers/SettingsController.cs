using Safety.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Safety.Web.Models;
using System.Diagnostics;
using AutoMapper;
using Safety.Domain.Interfaces.Services;
using Safety.Domain.Interfaces;
using Safety.Domain.Entities;
using Safety.Domain.Constants;

namespace Safety.Web.Controllers
{
    public class SettingsController : BaseController
    {
        private readonly IFuncionarioService _employeeService;

        public SettingsController(
            IMapper mapper,
            IAppLogger logger,
            IFuncionarioService employeeService) : base(logger, mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            //Funcionario employee = await _employeeService.GetByIdRelatedAsync(id.GetValueOrDefault(-1));

            //if (employee == null)
            //{
            //    return NotFound();
            //}

            //AutoMapper
            //FuncionarioViewModel employeeViewModel = _mapper.Map<Funcionario, FuncionarioViewModel>(employee);

            FuncionarioViewModel funcionarioViewModel = new FuncionarioViewModel();

            _logger.LogInformation(FuncionarioConst.LOG_INDEX, GetUserName(), DateTime.Now);

            return View(funcionarioViewModel);
        }
    }
}