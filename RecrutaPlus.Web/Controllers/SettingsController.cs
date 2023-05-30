using RecrutaPlus.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using RecrutaPlus.Web.Models;
using System.Diagnostics;
using AutoMapper;
using RecrutaPlus.Domain.Interfaces.Services;
using RecrutaPlus.Domain.Interfaces;
using RecrutaPlus.Domain.Entities;
using RecrutaPlus.Domain.Constants;

namespace RecrutaPlus.Web.Controllers
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

        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Funcionario employee = await _employeeService.GetByIdRelatedAsync(id.GetValueOrDefault(-1));

            if (employee == null)
            {
                return NotFound();
            }

            //AutoMapper
            FuncionarioViewModel employeeViewModel = _mapper.Map<Funcionario, FuncionarioViewModel>(employee);

            _logger.LogInformation(FuncionarioConst.LOG_INDEX, GetUserName(), DateTime.Now);

            return View(employeeViewModel);
        }
    }
}