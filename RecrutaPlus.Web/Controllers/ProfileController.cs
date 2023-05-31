using RecrutaPlus.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using RecrutaPlus.Web.Models;
using System.Diagnostics;
using RecrutaPlus.Domain.Interfaces.Services;
using AutoMapper;
using RecrutaPlus.Domain.Interfaces;
using RecrutaPlus.Domain.Constants;
using RecrutaPlus.Domain.Entities;

namespace RecrutaPlus.Web.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly IFuncionarioService _employeeService;

        public ProfileController(
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
                //Funcionario employee = await _employeeService.GetByIdRelatedAsync(id.GetValueOrDefault(-1));
                return NotFound();
            }
            else
            {
                //Funcionario employee = await _employeeService.GetAllAsync();
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