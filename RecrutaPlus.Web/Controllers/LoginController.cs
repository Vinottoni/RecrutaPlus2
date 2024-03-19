using Safety.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Safety.Web.Models;
using System.Diagnostics;
using Safety.Domain.Entities;
using Safety.Domain.Interfaces.Services;
using AutoMapper;
using Safety.Domain.Interfaces;
using Safety.Domain.Services;
using Safety.Domain.Constants;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Safety.Domain.Interfaces.Repositories;

namespace Safety.Web.Controllers
{
    public class LoginController : BaseController
    {
        private readonly ILoginRepository _loginRepository;

        public LoginController(
            ILoginRepository loginRepository,
            IMapper mapper,
            IAppLogger logger,
            ILoginService loginService) : base(logger, mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _loginRepository = loginRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginViewModel loginViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //LoginViewModel usuario = _loginRepository.BuscarPorLogin(loginViewModel.Username);

                    //if(usuario != null) {
                    //    if ( usuario.SenhaValida(loginViewModel.Password))
                    //    {
                    //        return RedirectToAction("Index", "Dashboard");
                    //    }

                    //    TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s). Por favor, tente novamente.";
                    //}
                    if (loginViewModel.Username == "RecrutaPlus@fatec.com" && loginViewModel.Password == "XXXrecrutaplus")
                    //if (loginViewModel.Username == loginViewModel.emailFuncionario && loginViewModel.Password == "XXXrecrutaplus")
                    {
                        return RedirectToAction("Index", "Dashboard");
                    }
                    TempData["MensagemErro"] = $"Username ou Senha inválido(s). Por favor, tente novamente.";
                    //TempData["MensagemErro"] = $"Senha inválido(s). Por favor, tente novamente.";
                }

                return View("Index");
            }
            catch (Exception erro) {
                TempData["MensagemErro"] = $"Não foi Possivel Realizar seu Login, tente Novamente mais tarde, Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Logout()
        {
            LoginViewModel loginViewModel = new LoginViewModel();


            return View(loginViewModel);
        }

    }
}