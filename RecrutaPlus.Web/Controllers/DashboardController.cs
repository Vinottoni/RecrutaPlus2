﻿using RecrutaPlus.Application.ViewModels;
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