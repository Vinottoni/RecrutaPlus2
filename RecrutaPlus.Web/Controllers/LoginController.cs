using RecrutaPlus.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using RecrutaPlus.Web.Models;
using System.Diagnostics;
using RecrutaPlus.Domain.Entities;
using RecrutaPlus.Domain.Interfaces.Services;
using AutoMapper;
using RecrutaPlus.Domain.Interfaces;
using RecrutaPlus.Domain.Services;
using RecrutaPlus.Domain.Constants;

namespace RecrutaPlus.Web.Controllers
{
    public class LoginController : BaseController
    {
        private readonly ILoginService _loginService;

        public LoginController(
            IMapper mapper,
            IAppLogger logger,
            ILoginService loginService) : base(logger, mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _loginService = loginService;
        }

        public async Task<IActionResult> Index(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //Login login = await _loginService.GetByIdRelatedAsync(id.GetValueOrDefault(-1));

            //if (login == null)
            //{
            //    return NotFound();
            //}


            ////AutoMapper
            //LoginViewModel loginViewModel = _mapper.Map<Login, LoginViewModel>(login);
            LoginViewModel loginViewModel = new LoginViewModel();

            _logger.LogInformation(FuncionarioConst.LOG_INDEX, GetUserName(), DateTime.Now);

            return View(loginViewModel);
        }

        public IActionResult Logout()
        {
            LoginViewModel loginViewModel = new LoginViewModel();


            return View(loginViewModel);
        }

    }
}