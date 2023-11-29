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
using Microsoft.AspNetCore.Mvc.Rendering;
using RecrutaPlus.Domain.Enums;

namespace RecrutaPlus.Web.Controllers
{
    public class FuncionariosController : BaseController
    {
        private readonly IFuncionarioService _funcionarioService;
        private readonly ICargoService _cargoService;
        private readonly IFeriasService _feriasService;

        public FuncionariosController(
            IMapper mapper,
            IAppLogger logger,
            IFuncionarioService funcionarioService,
            ICargoService cargoService,
            IFeriasService feriasService) : base(logger, mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _funcionarioService = funcionarioService;
            _cargoService = cargoService;
            _feriasService = feriasService;
        }

        public async Task<IActionResult> Index(int? id, bool state = false)
        {
            ViewBag.SelectListCargos = await Task.Run(() => SelectListCargos());

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
            ViewBag.SelectListCargos = await Task.Run(() => SelectListCargos());

            IEnumerable<Funcionario> funcionarios;

            funcionarioSearch.HasFilter = false;

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

        public async Task<IActionResult> ResumoFuncionario(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            IEnumerable<Funcionario> funcionarios = await _funcionarioService.GetByQueryRelatedAsync(w => w.FuncionarioId == id.GetValueOrDefault(-1));

            Funcionario funcionario = funcionarios.FirstOrDefault();

            if (funcionario == null)
            {
                return NotFound();
            }

            //AutoMapper
            var funcionarioViewModel = _mapper.Map<Funcionario, FuncionarioViewModel>(funcionario);
            int DiasDeTrabalho = 22;

            funcionarioViewModel.ValeAlimentacao = funcionarioViewModel.DiariaVA * DiasDeTrabalho;
            funcionarioViewModel.ValeRefeicao = funcionario.Salario * (decimal)0.06;
            funcionarioViewModel.ValeTransporte = funcionario.Salario * (decimal)0.06;

            funcionarioViewModel.MesReferencia = DateTime.Now.AddMonths(-1);

            _logger.LogInformation(FuncionarioConst.LOG_DETAILS, User.Identity.Name ?? DefaultConst.USER_ANONYMOUS, DateTime.Now);

            return View(funcionarioViewModel);
        }

        public async Task<IActionResult> ResumoFuncionarioPrint(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IEnumerable<Funcionario> funcionarios = await _funcionarioService.GetByQueryRelatedAsync(w => w.FuncionarioId == id.GetValueOrDefault(-1));

            Funcionario funcionario = funcionarios.FirstOrDefault();

            if (funcionario == null)
            {
                return NotFound();
            }

            //AutoMapper
            var funcionarioViewModel = _mapper.Map<Funcionario, FuncionarioViewModel>(funcionario);
            int DiasDeTrabalho = 22;

            funcionarioViewModel.ValeAlimentacao = funcionarioViewModel.DiariaVA * DiasDeTrabalho;
            funcionarioViewModel.ValeRefeicao = funcionario.Salario * (decimal)0.06;
            funcionarioViewModel.ValeTransporte = funcionario.Salario * (decimal)0.06;

            funcionarioViewModel.MesReferencia = DateTime.Now.AddMonths(-1);

            _logger.LogInformation(FuncionarioConst.LOG_DETAILS, User.Identity.Name ?? DefaultConst.USER_ANONYMOUS, DateTime.Now);

            return View(funcionarioViewModel);
        }

        public async Task<IActionResult> CalculoFeriasCreate(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            IEnumerable<Funcionario> funcionarios = await _funcionarioService.GetByQueryRelatedAsync(w => w.FuncionarioId == id.GetValueOrDefault(-1));

            Funcionario funcionario = funcionarios.FirstOrDefault();

            //IEnumerable<Ferias> feriass = await _feriasService.GetByQueryRelatedAsync(w => w.FuncionarioId == id.GetValueOrDefault(-1));

            //Ferias ferias = feriass.FirstOrDefault();

            if (funcionario == null)
            {
                return NotFound();
            }

            FuncionarioViewModel funcionarioViewModel = _mapper.Map<Funcionario, FuncionarioViewModel>(funcionario);


            _logger.LogInformation(FuncionarioConst.LOG_DETAILS, User.Identity.Name ?? DefaultConst.USER_ANONYMOUS, DateTime.Now);

            return View(funcionarioViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CalculoFeriasCreate(int? id, FuncionarioViewModel funcionarioViewModel)
        {
            if (id == null)
            {
                return NotFound();
            }

            //AutoMapper
            var ferias = _mapper.Map<FeriasViewModel, Ferias>(funcionarioViewModel.Ferias);
            var funcionario = _mapper.Map<FuncionarioViewModel, Funcionario>(funcionarioViewModel);

            ferias.FuncionarioId = id;
            

            funcionario.Salario = funcionarioViewModel.SalarioFinal;
                
            #region Cálculos da Folha de Pagamento

            int DiasDeTrabalho = 22;
            double SalarioINSS = 0;
            decimal descontoIRRF = 0;
            double SalarioFuncionario = (double)funcionario.Salario;

            funcionarioViewModel.ValeAlimentacao = funcionarioViewModel.DiariaVA * DiasDeTrabalho;

            decimal totalFaixaUm = 0;
            decimal totalFaixaDois = 0;
            decimal totalFaixaTres = 0;
            decimal totalFaixaQuatro = 0;

            decimal descontoFaixaUm = 0;
            decimal descontoFaixaDois = 0;
            decimal descontoFaixaTres = 0;
            decimal descontoFaixaQuatro = 0;

            #region Desconto Inss
            if (SalarioFuncionario <= 1320.00)
            {
                totalFaixaUm = (decimal)(1320.00 * 0.075);
                descontoFaixaUm = totalFaixaUm - (decimal)((1320.00 - SalarioFuncionario) * 0.075);
            }
            else if (SalarioFuncionario >= 1320.01 && SalarioFuncionario <= 2571.29)
            {
                //funcionario.INSS = funcionario.Salario * (decimal)0.09;
                totalFaixaUm = (decimal)(1320.00 * 0.075);
                totalFaixaDois = (decimal)((2571.29 - 1320.01) * 0.09);

                descontoFaixaUm = totalFaixaUm;
                descontoFaixaDois = totalFaixaDois - (decimal)((2571.29 - SalarioFuncionario) * 0.09);
            }
            else if (SalarioFuncionario >= 2571.30 && SalarioFuncionario <= 3856.94)
            {
                //funcionario.INSS = funcionario.Salario * (decimal)0.12;
                totalFaixaUm = (decimal)(1320.00 * 0.075);
                totalFaixaDois = (decimal)((2571.29 - 1320.01) * 0.09);
                totalFaixaTres = (decimal)((3856.94 - 2571.30) * 0.12);

                descontoFaixaUm = totalFaixaUm;
                descontoFaixaDois = totalFaixaDois;
                descontoFaixaTres = totalFaixaTres - (decimal)((3856.94 - SalarioFuncionario) * 0.12);
            }
            else if (SalarioFuncionario >= 3856.95 && SalarioFuncionario <= 7507.49)
            {
                //funcionario.INSS = funcionario.Salario * (decimal)0.14;
                totalFaixaUm = (decimal)(1320.00 * 0.075);
                totalFaixaDois = (decimal)((2571.29 - 1320.01) * 0.09);
                totalFaixaTres = (decimal)((3856.94 - 2571.301) * 0.12);
                totalFaixaQuatro = (decimal)((7507.49 - 3856.95) * 0.14);

                descontoFaixaUm = totalFaixaUm;
                descontoFaixaDois = totalFaixaDois;
                descontoFaixaTres = totalFaixaTres;
                descontoFaixaQuatro = totalFaixaQuatro - (decimal)((7507.49 - SalarioFuncionario) * 0.14);
            }
            else if (SalarioFuncionario > 7507.49)
            {
                totalFaixaUm = (decimal)(1320.00 * 0.075);
                totalFaixaDois = (decimal)((2571.29 - 1320.01) * 0.09);
                totalFaixaTres = (decimal)((3856.94 - 2571.301) * 0.12);
                totalFaixaQuatro = (decimal)((7507.49 - 3856.95) * 0.14);

                descontoFaixaUm = totalFaixaUm;
                descontoFaixaDois = totalFaixaDois;
                descontoFaixaTres = totalFaixaTres;
                descontoFaixaQuatro = totalFaixaQuatro;
            }
            #endregion

            funcionario.INSS = totalFaixaUm + totalFaixaDois + totalFaixaTres + totalFaixaQuatro;

            SalarioINSS = SalarioFuncionario - (double)funcionario.INSS;
            decimal totalFaixaUmIRRF = 0;
            decimal totalFaixaDoisIRRF = 0;
            decimal totalFaixaTresIRRF = 0;
            decimal totalFaixaQuatroIRRF = 0;
            decimal totalFaixaCincoIRRF = 0;

            decimal descontoFaixaUmIRRF = 0;
            decimal descontoFaixaDoisIRRF = 0;
            decimal descontoFaixaTresIRRF = 0;
            decimal descontoFaixaQuatroIRRF = 0;
            decimal descontoFaixaCincoIRRF = 0;
            decimal descontoTotalIrrf = 0;

            double SalarioIRRF = 0;

            SalarioIRRF = SalarioFuncionario - ((double)funcionario.INSS + (double)(funcionario.Dependentes * 189.59));

            #region Desconto IRRF
            if (SalarioIRRF <= 2112.00)
            {
                totalFaixaUmIRRF = 0;
            }
            else if (SalarioIRRF >= 2112.01 && SalarioIRRF <= 2826.65)
            {
                totalFaixaUmIRRF = 0;
                totalFaixaDoisIRRF = (decimal)((2826.65 - 2112.01) * 0.075);

                descontoFaixaDoisIRRF = totalFaixaDoisIRRF - (decimal)((2826.65 - SalarioIRRF) * 0.075);
            }
            else if (SalarioIRRF >= 2826.66 && SalarioIRRF <= 3751.05)
            {
                totalFaixaUmIRRF = 0;
                totalFaixaDoisIRRF = (decimal)((2826.65 - 2112.01) * 0.075);
                totalFaixaTresIRRF = (decimal)((3751.05 - 2826.66) * 0.15);

                descontoFaixaDoisIRRF = totalFaixaDoisIRRF;
                descontoFaixaTresIRRF = totalFaixaTresIRRF - (decimal)((3751.05 - SalarioIRRF) * 0.15);
            }
            else if (SalarioIRRF >= 3751.06 && SalarioIRRF <= 4664.68)
            {
                totalFaixaUmIRRF = 0;
                totalFaixaDoisIRRF = (decimal)((2826.65 - 2112.01) * 0.075);
                totalFaixaTresIRRF = (decimal)((3751.05 - 2826.66) * 0.15);
                totalFaixaQuatroIRRF = (decimal)((4664.68 - 3751.06) * 0.225);

                descontoFaixaDoisIRRF = totalFaixaDoisIRRF;
                descontoFaixaTresIRRF = totalFaixaTresIRRF;
                descontoFaixaQuatroIRRF = totalFaixaQuatroIRRF - (decimal)((4664.68 - SalarioIRRF) * 0.225);
            }
            else if (SalarioIRRF > 4664.68)
            {
                totalFaixaUmIRRF = 0;
                totalFaixaDoisIRRF = (decimal)((2826.65 - 2112.01) * 0.075);
                totalFaixaTresIRRF = (decimal)((3751.05 - 2826.66) * 0.15);
                totalFaixaQuatroIRRF = (decimal)((4664.68 - 3751.06) * 0.225);

                descontoFaixaDoisIRRF = totalFaixaDoisIRRF;
                descontoFaixaTresIRRF = totalFaixaTresIRRF;
                descontoFaixaQuatroIRRF = totalFaixaQuatroIRRF;
                descontoFaixaCincoIRRF = (decimal)((SalarioIRRF - 4664.68) * 0.275);
            }

            descontoTotalIrrf = descontoIRRF + descontoFaixaDoisIRRF + descontoFaixaTresIRRF + descontoFaixaQuatroIRRF + descontoFaixaCincoIRRF;

            funcionario.IRRF = descontoTotalIrrf;

            funcionario.FGTS = funcionario.Salario * (decimal)0.08;

            funcionario.TotalDescontos = funcionario.INSS + funcionario.IRRF + funcionario.FGTS;

            funcionario.SalarioLiquido = funcionario.Salario - funcionario.TotalDescontos;
            #endregion

            #endregion

            #region Cálculos das Férias

            ferias.Dependentes = funcionario.Dependentes;
            ferias.ValorHoraExtra = funcionarioViewModel.Ferias.ValorHoraExtra;

            #endregion

            ferias.Cadastro = DateTime.Now;
            ferias.CadastradoPor = User.Identity.Name ?? DefaultConst.USER_ANONYMOUS;
            ferias.Edicao = DateTime.Now;
            ferias.EditadoPor = User.Identity.Name ?? DefaultConst.USER_ANONYMOUS;
            ferias.GuidStamp = Guid.NewGuid();

            ServiceResult serviceResult = _feriasService.Add(ferias);

            _ = await _feriasService.SaveChangesAsync();

            SuccessMessage = FuncionarioResource.MSG_SAVED_SUCCESSFULLY;

            _logger.LogInformation(FuncionarioConst.LOG_CREATE, User.Identity.Name ?? DefaultConst.USER_ANONYMOUS, DateTime.Now);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CalculoFeriasDetails(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            IEnumerable<Funcionario> funcionarios = await _funcionarioService.GetByQueryRelatedAsync(w => w.FuncionarioId == id.GetValueOrDefault(-1));
            IEnumerable<Ferias> feriass = await _feriasService.GetByQueryRelatedAsync(w => w.FuncionarioId == id.GetValueOrDefault(-1));

            Ferias ferias = feriass.LastOrDefault();

            Funcionario funcionario = funcionarios.FirstOrDefault();

            if (funcionario == null)
            {
                return NotFound();
            }

            if (funcionario.Ativo == false)
            {
                return NotFound();
            }


            //AutoMapper
            var funcionarioViewModel = _mapper.Map<Funcionario, FuncionarioViewModel>(funcionario);
            var feriasViewModel = _mapper.Map<Ferias, FeriasViewModel>(ferias);

            int DiasDeTrabalho = 22;

            if(funcionario.Dependentes > 0)
            {
                funcionarioViewModel.DescontoDependente = (decimal)(funcionario?.Dependentes * 189.59);
            }
            else
            {
                funcionarioViewModel.DescontoDependente = 0;
            }

            funcionarioViewModel.DiasFerias = ferias.DiasFerias;
            funcionarioViewModel.ValeAlimentacao = funcionarioViewModel.DiariaVA * DiasDeTrabalho;
            funcionarioViewModel.ValeRefeicao = funcionario.Salario * (decimal)0.06;
            funcionarioViewModel.ValeTransporte = funcionario.Salario * (decimal)0.06;
            funcionarioViewModel.ValorHoraExtra = ferias.ValorHoraExtra;
            funcionarioViewModel.AbonoPecuniario = ferias.AbonoPecuniario;
            funcionarioViewModel.DecimoTerceiro = ferias.DecimoTerceiro;

            funcionarioViewModel.MesReferencia = DateTime.Now.AddMonths(-1);

            #region Cálculo de Férias

            //Valores Brutos
            decimal ValorDasFerias = (funcionario.Salario / 30) * ferias.DiasFerias;
            decimal UmTercoFerias = ValorDasFerias / 3; //Calcular 1/3 das Ferias
            decimal ValorDecimoTerceiro = 0;
            decimal ValorAbono = 0;
            decimal UmTercoAbono = 0;

            //Cálculo do 13º
            if (ferias.DecimoTerceiro == true)
            {
                ValorDecimoTerceiro = funcionario.Salario / 2;
            }
            else
            {
                ValorDecimoTerceiro = 0;
            }


            //Cálculo do Abono Pecuniário
            if (ferias.AbonoPecuniario == true)
            {
                ValorAbono = (funcionario.Salario / 30) * 10;
                UmTercoAbono = ValorAbono / 3;
            }
            else
            {
                ValorAbono = 0;
                UmTercoAbono = 0;
            }

            funcionarioViewModel.TotalBruto = funcionario.Salario + UmTercoFerias + ValorDecimoTerceiro + ValorAbono + UmTercoAbono; //Somar o bruto de tudo, salario, 1/3 das ferias, abono etc...

            //Descontos
            funcionarioViewModel.TotalLiquidoFerias = funcionarioViewModel.TotalBruto - funcionario.INSS - funcionario.IRRF;
            #endregion


            _logger.LogInformation(FuncionarioConst.LOG_DETAILS, User.Identity.Name ?? DefaultConst.USER_ANONYMOUS, DateTime.Now);

            return View(funcionarioViewModel);
        }

        public async Task<IActionResult> CalculoFeriasDetailsPrint(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            IEnumerable<Funcionario> funcionarios = await _funcionarioService.GetByQueryRelatedAsync(w => w.FuncionarioId == id.GetValueOrDefault(-1));
            IEnumerable<Ferias> feriass = await _feriasService.GetByQueryRelatedAsync(w => w.FuncionarioId == id.GetValueOrDefault(-1));

            Ferias ferias = feriass.LastOrDefault();

            Funcionario funcionario = funcionarios.FirstOrDefault();

            if (funcionario == null)
            {
                return NotFound();
            }

            //AutoMapper
            var funcionarioViewModel = _mapper.Map<Funcionario, FuncionarioViewModel>(funcionario);
            var feriasViewModel = _mapper.Map<Ferias, FeriasViewModel>(ferias);

            int DiasDeTrabalho = 22;

            if (funcionario.Dependentes > 0)
            {
                funcionarioViewModel.DescontoDependente = (decimal)(funcionario?.Dependentes * 189.59);
            }
            else
            {
                funcionarioViewModel.DescontoDependente = 0;
            }

            funcionarioViewModel.DiasFerias = ferias.DiasFerias;
            funcionarioViewModel.ValeAlimentacao = funcionarioViewModel.DiariaVA * DiasDeTrabalho;
            funcionarioViewModel.ValeRefeicao = funcionario.Salario * (decimal)0.06;
            funcionarioViewModel.ValeTransporte = funcionario.Salario * (decimal)0.06;
            funcionarioViewModel.ValorHoraExtra = ferias.ValorHoraExtra;
            funcionarioViewModel.AbonoPecuniario = ferias.AbonoPecuniario;
            funcionarioViewModel.DecimoTerceiro = ferias.DecimoTerceiro;

            funcionarioViewModel.MesReferencia = DateTime.Now.AddMonths(-1);

            #region Cálculo de Férias

            //Valores Brutos
            decimal ValorDasFerias = (funcionario.Salario / 30) * ferias.DiasFerias;
            decimal UmTercoFerias = ValorDasFerias / 3; //Calcular 1/3 das Ferias
            decimal ValorDecimoTerceiro = 0;
            decimal ValorAbono = 0;
            decimal UmTercoAbono = 0;

            //Cálculo do 13º
            if (ferias.DecimoTerceiro == true)
            {
                ValorDecimoTerceiro = funcionario.Salario / 2;
            }
            else
            {
                ValorDecimoTerceiro = 0;
            }


            //Cálculo do Abono Pecuniário
            if (ferias.AbonoPecuniario == true)
            {
                ValorAbono = (funcionario.Salario / 30) * 10;
                UmTercoAbono = ValorAbono / 3;
            }
            else
            {
                ValorAbono = 0;
                UmTercoAbono = 0;
            }

            funcionarioViewModel.TotalBruto = funcionario.Salario + UmTercoFerias + ValorDecimoTerceiro + ValorAbono + UmTercoAbono; //Somar o bruto de tudo, salario, 1/3 das ferias, abono etc...

            //Descontos
            funcionarioViewModel.TotalLiquidoFerias = funcionarioViewModel.TotalBruto - funcionario.INSS - funcionario.IRRF;
            #endregion


            _logger.LogInformation(FuncionarioConst.LOG_DETAILS, User.Identity.Name ?? DefaultConst.USER_ANONYMOUS, DateTime.Now);

            return View(funcionarioViewModel);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.SelectListCargos = await Task.Run(() => SelectListCargos());
            ViewBag.SelectListGenero = await Task.Run(() => SelectListGenero());
            ViewBag.SelectListEducacao = await Task.Run(() => SelectListEducacao());

            FuncionarioViewModel funcionarioViewModel = await Task.Run(() => new FuncionarioViewModel());

            _logger.LogInformation(FuncionarioConst.LOG_CREATE, User.Identity.Name ?? DefaultConst.USER_ANONYMOUS, DateTime.Now);

            return View(funcionarioViewModel);
        }

        //[Authorize(Policy = AuthorizationPolicyConst.REGISTER_CREATE)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FuncionarioViewModel funcionarioViewModel)
        {
            //AutoMapper
            var funcionario = _mapper.Map<FuncionarioViewModel, Funcionario>(funcionarioViewModel);

            funcionario.Salario = funcionarioViewModel.SalarioFinal;

            funcionario.Ativo = true;

            int DiasDeTrabalho = 22;
            double SalarioINSS = 0;
            decimal descontoIRRF = 0;
            double SalarioFuncionario = (double)funcionario.Salario;

            funcionarioViewModel.ValeAlimentacao = funcionarioViewModel.DiariaVA * DiasDeTrabalho;

            decimal totalFaixaUm = 0;
            decimal totalFaixaDois = 0;
            decimal totalFaixaTres = 0;
            decimal totalFaixaQuatro = 0;

            decimal descontoFaixaUm = 0;
            decimal descontoFaixaDois = 0;
            decimal descontoFaixaTres = 0;
            decimal descontoFaixaQuatro = 0;

            #region Desconto Inss
            if (SalarioFuncionario <= 1320.00)
            {
                totalFaixaUm = (decimal)(1320.00 * 0.075);
                descontoFaixaUm = totalFaixaUm - (decimal)((1320.00 - SalarioFuncionario) * 0.075);
            }
            else if (SalarioFuncionario >= 1320.01 && SalarioFuncionario <= 2571.29)
            {
                //funcionario.INSS = funcionario.Salario * (decimal)0.09;
                totalFaixaUm = (decimal)(1320.00 * 0.075);
                totalFaixaDois = (decimal)((2571.29 - 1320.01) * 0.09);

                descontoFaixaUm = totalFaixaUm;
                descontoFaixaDois = totalFaixaDois - (decimal)((2571.29 - SalarioFuncionario) * 0.09);
            }
            else if (SalarioFuncionario >= 2571.30 && SalarioFuncionario <= 3856.94)
            {
                //funcionario.INSS = funcionario.Salario * (decimal)0.12;
                totalFaixaUm = (decimal)(1320.00 * 0.075);
                totalFaixaDois = (decimal)((2571.29 - 1320.01) * 0.09);
                totalFaixaTres = (decimal)((3856.94 - 2571.30) * 0.12);

                descontoFaixaUm = totalFaixaUm;
                descontoFaixaDois = totalFaixaDois;
                descontoFaixaTres = totalFaixaTres - (decimal)((3856.94 - SalarioFuncionario) * 0.12);
            }
            else if (SalarioFuncionario >= 3856.95 && SalarioFuncionario <= 7507.49)
            {
                //funcionario.INSS = funcionario.Salario * (decimal)0.14;
                totalFaixaUm = (decimal)(1320.00 * 0.075);
                totalFaixaDois = (decimal)((2571.29 - 1320.01) * 0.09);
                totalFaixaTres = (decimal)((3856.94 - 2571.301) * 0.12);
                totalFaixaQuatro = (decimal)((7507.49 - 3856.95) * 0.14);

                descontoFaixaUm = totalFaixaUm;
                descontoFaixaDois = totalFaixaDois;
                descontoFaixaTres = totalFaixaTres;
                descontoFaixaQuatro = totalFaixaQuatro - (decimal)((7507.49 - SalarioFuncionario) * 0.14);
            }
            else if (SalarioFuncionario > 7507.49)
            {
                totalFaixaUm = (decimal)(1320.00 * 0.075);
                totalFaixaDois = (decimal)((2571.29 - 1320.01) * 0.09);
                totalFaixaTres = (decimal)((3856.94 - 2571.301) * 0.12);
                totalFaixaQuatro = (decimal)((7507.49 - 3856.95) * 0.14);

                descontoFaixaUm = totalFaixaUm;
                descontoFaixaDois = totalFaixaDois;
                descontoFaixaTres = totalFaixaTres;
                descontoFaixaQuatro = totalFaixaQuatro;
            }
            #endregion

            funcionario.INSS = totalFaixaUm + totalFaixaDois + totalFaixaTres + totalFaixaQuatro;

            SalarioINSS = SalarioFuncionario - (double)funcionario.INSS;
            decimal totalFaixaUmIRRF = 0;
            decimal totalFaixaDoisIRRF = 0;
            decimal totalFaixaTresIRRF = 0;
            decimal totalFaixaQuatroIRRF = 0;
            decimal totalFaixaCincoIRRF = 0;

            decimal descontoFaixaUmIRRF = 0;
            decimal descontoFaixaDoisIRRF = 0;
            decimal descontoFaixaTresIRRF = 0;
            decimal descontoFaixaQuatroIRRF = 0;
            decimal descontoFaixaCincoIRRF = 0;
            decimal descontoTotalIrrf = 0;

            double SalarioIRRF = 0;

            SalarioIRRF = SalarioFuncionario - ((double)funcionario.INSS + (double)(funcionario.Dependentes * 189.59));

            #region Desconto IRRF
            if (SalarioIRRF <= 2112.00)
            {
                totalFaixaUmIRRF = 0;
            }
            else if (SalarioIRRF >= 2112.01 && SalarioIRRF <= 2826.65)
            {
                totalFaixaUmIRRF = 0;
                totalFaixaDoisIRRF = (decimal)((2826.65 - 2112.01) * 0.075);

                descontoFaixaDoisIRRF = totalFaixaDoisIRRF - (decimal)((2826.65 - SalarioIRRF) * 0.075);
            }
            else if (SalarioIRRF >= 2826.66 && SalarioIRRF <= 3751.05)
            {
                totalFaixaUmIRRF = 0;
                totalFaixaDoisIRRF = (decimal)((2826.65 - 2112.01) * 0.075);
                totalFaixaTresIRRF = (decimal)((3751.05 - 2826.66) * 0.15);

                descontoFaixaDoisIRRF = totalFaixaDoisIRRF;
                descontoFaixaTresIRRF = totalFaixaTresIRRF - (decimal)((3751.05 - SalarioIRRF) * 0.15);
            }
            else if (SalarioIRRF >= 3751.06 && SalarioIRRF <= 4664.68)
            {
                totalFaixaUmIRRF = 0;
                totalFaixaDoisIRRF = (decimal)((2826.65 - 2112.01) * 0.075);
                totalFaixaTresIRRF = (decimal)((3751.05 - 2826.66) * 0.15);
                totalFaixaQuatroIRRF = (decimal)((4664.68 - 3751.06) * 0.225);

                descontoFaixaDoisIRRF = totalFaixaDoisIRRF;
                descontoFaixaTresIRRF = totalFaixaTresIRRF;
                descontoFaixaQuatroIRRF = totalFaixaQuatroIRRF - (decimal)((4664.68 - SalarioIRRF) * 0.225);
            }
            else if (SalarioIRRF > 4664.68)
            {
                totalFaixaUmIRRF = 0;
                totalFaixaDoisIRRF = (decimal)((2826.65 - 2112.01) * 0.075);
                totalFaixaTresIRRF = (decimal)((3751.05 - 2826.66) * 0.15);
                totalFaixaQuatroIRRF = (decimal)((4664.68 - 3751.06) * 0.225);

                descontoFaixaDoisIRRF = totalFaixaDoisIRRF;
                descontoFaixaTresIRRF = totalFaixaTresIRRF;
                descontoFaixaQuatroIRRF = totalFaixaQuatroIRRF;
                descontoFaixaCincoIRRF = (decimal)((SalarioIRRF - 4664.68) * 0.275);
            }

            descontoTotalIrrf = descontoIRRF + descontoFaixaDoisIRRF + descontoFaixaTresIRRF + descontoFaixaQuatroIRRF + descontoFaixaCincoIRRF;

            funcionario.IRRF = descontoTotalIrrf;

            funcionario.TotalDescontos = funcionario.INSS + funcionario.IRRF + funcionario.FGTS;

            funcionario.SalarioLiquido = funcionario.Salario - funcionario.TotalDescontos;
            #endregion

            funcionario.Cadastro = DateTime.Now;
            funcionario.CadastradoPor = User.Identity.Name ?? DefaultConst.USER_ANONYMOUS;
            funcionario.Edicao = DateTime.Now;
            funcionario.EditadoPor = User.Identity.Name ?? DefaultConst.USER_ANONYMOUS;
            funcionario.GuidStamp = Guid.NewGuid();

            ServiceResult serviceResult = _funcionarioService.Add(funcionario);

            //Validation
            if (serviceResult.HasErrors)
            {
                ViewBag.SelectListCargos = await Task.Run(() => SelectListCargos());
                ViewBag.SelectListGenero = await Task.Run(() => SelectListGenero());
                ViewBag.SelectListEducacao = await Task.Run(() => SelectListEducacao());

                serviceResult.ToModelStateDictionary(ModelState);

                return View(funcionarioViewModel);
            }

            _ = await _funcionarioService.SaveChangesAsync();

            SuccessMessage = FuncionarioResource.MSG_SAVED_SUCCESSFULLY;

            _logger.LogInformation(FuncionarioConst.LOG_CREATE, User.Identity.Name ?? DefaultConst.USER_ANONYMOUS, DateTime.Now);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.SelectListGenero = await Task.Run(() => SelectListGenero());
            ViewBag.SelectListEducacao = await Task.Run(() => SelectListEducacao());
            ViewBag.SelectListCargoToString = await Task.Run(() => SelectListCargoToString());

            if (id == null)
            {
                return NotFound();
            }

            IEnumerable<Funcionario> funcionarios = await _funcionarioService.GetByQueryRelatedAsync(w => w.FuncionarioId == id.GetValueOrDefault(-1));

            Funcionario funcionario = funcionarios.FirstOrDefault();

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
            ViewBag.SelectListCargos = await Task.Run(() => SelectListCargos());
            ViewBag.SelectListGenero = await Task.Run(() => SelectListGenero());
            ViewBag.SelectListEducacao = await Task.Run(() => SelectListEducacao());

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
            ViewBag.SelectListCargos = await Task.Run(() => SelectListCargos());
            ViewBag.SelectListGenero = await Task.Run(() => SelectListGenero());
            ViewBag.SelectListEducacao = await Task.Run(() => SelectListEducacao());

            if (id != funcionarioViewModel.FuncionarioId)
            {
                return NotFound();
            }

            //AutoMapper
            var funcionario = _mapper.Map<FuncionarioViewModel, Funcionario>(funcionarioViewModel);


            funcionario.Salario = funcionarioViewModel.SalarioFinal;

            int DiasDeTrabalho = 22;
            double SalarioINSS = 0;
            decimal descontoIRRF = 0;
            double SalarioFuncionario = (double)funcionario.Salario;

            funcionarioViewModel.ValeAlimentacao = funcionarioViewModel.DiariaVA * DiasDeTrabalho;

            decimal totalFaixaUm = 0;
            decimal totalFaixaDois = 0;
            decimal totalFaixaTres = 0;
            decimal totalFaixaQuatro = 0;

            decimal descontoFaixaUm = 0;
            decimal descontoFaixaDois = 0;
            decimal descontoFaixaTres = 0;
            decimal descontoFaixaQuatro = 0;

            #region Desconto Inss
            if (SalarioFuncionario <= 1320.00)
            {
                totalFaixaUm = (decimal)(1320.00 * 0.075);
                descontoFaixaUm = totalFaixaUm - (decimal)((1320.00 - SalarioFuncionario) * 0.075);
            }
            else if (SalarioFuncionario >= 1320.01 && SalarioFuncionario <= 2571.29)
            {
                //funcionario.INSS = funcionario.Salario * (decimal)0.09;
                totalFaixaUm = (decimal)(1320.00 * 0.075);
                totalFaixaDois = (decimal)((2571.29 - 1320.01) * 0.09);

                descontoFaixaUm = totalFaixaUm;
                descontoFaixaDois = totalFaixaDois - (decimal)((2571.29 - SalarioFuncionario) * 0.09);
            }
            else if (SalarioFuncionario >= 2571.30 && SalarioFuncionario <= 3856.94)
            {
                //funcionario.INSS = funcionario.Salario * (decimal)0.12;
                totalFaixaUm = (decimal)(1320.00 * 0.075);
                totalFaixaDois = (decimal)((2571.29 - 1320.01) * 0.09);
                totalFaixaTres = (decimal)((3856.94 - 2571.30) * 0.12);

                descontoFaixaUm = totalFaixaUm;
                descontoFaixaDois = totalFaixaDois;
                descontoFaixaTres = totalFaixaTres - (decimal)((3856.94 - SalarioFuncionario) * 0.12);
            }
            else if (SalarioFuncionario >= 3856.95 && SalarioFuncionario <= 7507.49)
            {
                //funcionario.INSS = funcionario.Salario * (decimal)0.14;
                totalFaixaUm = (decimal)(1320.00 * 0.075);
                totalFaixaDois = (decimal)((2571.29 - 1320.01) * 0.09);
                totalFaixaTres = (decimal)((3856.94 - 2571.301) * 0.12);
                totalFaixaQuatro = (decimal)((7507.49 - 3856.95) * 0.14);

                descontoFaixaUm = totalFaixaUm;
                descontoFaixaDois = totalFaixaDois;
                descontoFaixaTres = totalFaixaTres;
                descontoFaixaQuatro = totalFaixaQuatro - (decimal)((7507.49 - SalarioFuncionario) * 0.14);
            }
            else if (SalarioFuncionario > 7507.49)
            {
                totalFaixaUm = (decimal)(1320.00 * 0.075);
                totalFaixaDois = (decimal)((2571.29 - 1320.01) * 0.09);
                totalFaixaTres = (decimal)((3856.94 - 2571.301) * 0.12);
                totalFaixaQuatro = (decimal)((7507.49 - 3856.95) * 0.14);

                descontoFaixaUm = totalFaixaUm;
                descontoFaixaDois = totalFaixaDois;
                descontoFaixaTres = totalFaixaTres;
                descontoFaixaQuatro = totalFaixaQuatro;
            }
            #endregion

            funcionario.INSS = descontoFaixaUm + descontoFaixaDois + descontoFaixaTres + descontoFaixaQuatro;

            SalarioINSS = SalarioFuncionario - (double)funcionario.INSS;

            decimal totalFaixaUmIRRF = 0;
            decimal totalFaixaDoisIRRF = 0;
            decimal totalFaixaTresIRRF = 0;
            decimal totalFaixaQuatroIRRF = 0;
            decimal totalFaixaCincoIRRF = 0;

            decimal descontoFaixaUmIRRF = 0;
            decimal descontoFaixaDoisIRRF = 0;
            decimal descontoFaixaTresIRRF = 0;
            decimal descontoFaixaQuatroIRRF = 0;
            decimal descontoFaixaCincoIRRF = 0;
            decimal descontoTotalIrrf = 0;

            double SalarioIRRF = 0;

            SalarioIRRF = SalarioFuncionario - ((double)funcionario.INSS + (double)(funcionario.Dependentes * 189.59));

            #region Desconto IRRF
            if (SalarioIRRF <= 2112.00)
            {
                totalFaixaUmIRRF = 0;
            }
            else if (SalarioIRRF >= 2112.01 && SalarioIRRF <= 2826.65)
            {
                totalFaixaUmIRRF = 0;
                totalFaixaDoisIRRF = (decimal)((2826.65 - 2112.01) * 0.075);

                descontoFaixaDoisIRRF = totalFaixaDoisIRRF - (decimal)((2826.65 - SalarioIRRF) * 0.075);
            }
            else if (SalarioIRRF >= 2826.66 && SalarioIRRF <= 3751.05)
            {
                totalFaixaUmIRRF = 0;
                totalFaixaDoisIRRF = (decimal)((2826.65 - 2112.01) * 0.075);
                totalFaixaTresIRRF = (decimal)((3751.05 - 2826.66) * 0.15);

                descontoFaixaDoisIRRF = totalFaixaDoisIRRF;
                descontoFaixaTresIRRF = totalFaixaTresIRRF - (decimal)((3751.05 - SalarioIRRF) * 0.15);
            }
            else if (SalarioIRRF >= 3751.06 && SalarioIRRF <= 4664.68)
            {
                totalFaixaUmIRRF = 0;
                totalFaixaDoisIRRF = (decimal)((2826.65 - 2112.01) * 0.075);
                totalFaixaTresIRRF = (decimal)((3751.05 - 2826.66) * 0.15);
                totalFaixaQuatroIRRF = (decimal)((4664.68 - 3751.06) * 0.225);

                descontoFaixaDoisIRRF = totalFaixaDoisIRRF;
                descontoFaixaTresIRRF = totalFaixaTresIRRF;
                descontoFaixaQuatroIRRF = totalFaixaQuatroIRRF - (decimal)((4664.68 - SalarioIRRF) * 0.225);
            }
            else if (SalarioIRRF > 4664.68)
            {
                totalFaixaUmIRRF = 0;
                totalFaixaDoisIRRF = (decimal)((2826.65 - 2112.01) * 0.075);
                totalFaixaTresIRRF = (decimal)((3751.05 - 2826.66) * 0.15);
                totalFaixaQuatroIRRF = (decimal)((4664.68 - 3751.06) * 0.225);

                descontoFaixaDoisIRRF = totalFaixaDoisIRRF;
                descontoFaixaTresIRRF = totalFaixaTresIRRF;
                descontoFaixaQuatroIRRF = totalFaixaQuatroIRRF;
                descontoFaixaCincoIRRF = (decimal)((SalarioIRRF - 4664.68) * 0.275);
            }

            descontoTotalIrrf = descontoIRRF + descontoFaixaDoisIRRF + descontoFaixaTresIRRF + descontoFaixaQuatroIRRF + descontoFaixaCincoIRRF;

            funcionario.IRRF = descontoTotalIrrf;

            funcionario.FGTS = funcionario.Salario * (decimal)0.08;

            funcionario.TotalDescontos = funcionario.INSS + funcionario.IRRF + funcionario.FGTS;

            funcionario.SalarioLiquido = funcionario.Salario - funcionario.TotalDescontos;

            #endregion

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

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.SelectListGenero = await Task.Run(() => SelectListGenero());
            ViewBag.SelectListEducacao = await Task.Run(() => SelectListEducacao());
            ViewBag.SelectListCargoToString = await Task.Run(() => SelectListCargoToString());

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
                return RedirectToAction(nameof(Delete));
            }

            if (funcionario.Ativo == false)
            {
                _ = await _funcionarioService.SaveChangesAsync();

                SuccessMessage = DefaultResource.MSG_SAVED_SUCCESSFULLY;

                _logger.LogInformation(FuncionarioConst.LOG_DELETE, User.Identity.Name ?? DefaultConst.USER_ANONYMOUS, DateTime.Now);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

            //_ = await _funcionarioService.SaveChangesAsync();

            //SuccessMessage = DefaultResource.MSG_SAVED_SUCCESSFULLY;

            //_logger.LogInformation(FuncionarioConst.LOG_DELETE, User.Identity.Name ?? DefaultConst.USER_ANONYMOUS, DateTime.Now);

            //return RedirectToAction(nameof(Index));
        }

        #region SelectList

        private async Task<List<SelectListItem>> SelectListCargos()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            IEnumerable<Cargo> cargos = await _cargoService.GetAllAsync();

            selectListItems.Add(new SelectListItem(DefaultResource.MSG_SELECIONE, string.Empty, true));

            foreach (var item in cargos.OrderBy(o => o.Nome))
            {
                selectListItems.Add(new SelectListItem(text: item.Nome, value: item.CargoId.ToString()));
            }

            return selectListItems;
        }

        private async Task<List<SelectListItem>> SelectListGenero()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();

            await Task.Run(() =>
            {
                selectListItems.Add(new SelectListItem(DefaultResource.MSG_SELECIONE, string.Empty, true));
                selectListItems.Add(new SelectListItem(FuncionarioResource.GENERO_MASCULINO, ((int)GeneroEnum.Masculino).ToString(), false));
                selectListItems.Add(new SelectListItem(FuncionarioResource.GENERO_FEMININO, ((int)GeneroEnum.Feminino).ToString(), false)); ;
                selectListItems.Add(new SelectListItem(FuncionarioResource.GENERO_LGBTQIAMAIS, ((int)GeneroEnum.LGBTQIAMAIS).ToString(), false));
                selectListItems.Add(new SelectListItem(FuncionarioResource.GENERO_PREFIRO_NAO_RESPONDER, ((int)GeneroEnum.PrefiroNaoResponder).ToString(), false));
            });

            return selectListItems;
        }

        private async Task<List<SelectListItem>> SelectListEducacao()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();

            await Task.Run(() =>
            {
                selectListItems.Add(new SelectListItem(DefaultResource.MSG_SELECIONE, string.Empty, true));
                selectListItems.Add(new SelectListItem(FuncionarioResource.ENSINO_FUNDAMENTAL, ((int)EducacaoEnum.EnsinoFundamental).ToString(), false));
                selectListItems.Add(new SelectListItem(FuncionarioResource.ENSINO_FUNDAMENTAL_INCOMPLETO, ((int)EducacaoEnum.EnsinoFundamentalIncompleto).ToString(), false));
                selectListItems.Add(new SelectListItem(FuncionarioResource.ENSINO_MEDIO, ((int)EducacaoEnum.EnsinoMedio).ToString(), false)); ;
                selectListItems.Add(new SelectListItem(FuncionarioResource.ENSINO_MEDIO_INCOMPLETO, ((int)EducacaoEnum.EnsinoMedioIncompleto).ToString(), false)); ;
                selectListItems.Add(new SelectListItem(FuncionarioResource.ENSINO_SUPERIOR, ((int)EducacaoEnum.EnsinoSuperior).ToString(), false));
                selectListItems.Add(new SelectListItem(FuncionarioResource.ENSINO_SUPERIOR_INCOMPLETO, ((int)EducacaoEnum.EnsinoSuperiorIncompleto).ToString(), false));
            });

            return selectListItems;
        }

        private async Task<List<SelectListItem>> SelectListCargoToString()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();

            await Task.Run(() =>
            {
                selectListItems.Add(new SelectListItem(DefaultResource.MSG_SELECIONE, string.Empty, true));
                selectListItems.Add(new SelectListItem(FuncionarioResource.CEO_LABEL, ((int)CargoEnum.CEO).ToString(), false));
                selectListItems.Add(new SelectListItem(FuncionarioResource.PRESIDENTE_LABEL, ((int)CargoEnum.Presidente).ToString(), false));
                selectListItems.Add(new SelectListItem(FuncionarioResource.COORDENADOR_SUPERVISOR_LABEL, ((int)CargoEnum.CoordenadorSupervisor).ToString(), false)); ;
                selectListItems.Add(new SelectListItem(FuncionarioResource.ANALISTA_LABEL, ((int)CargoEnum.Analista).ToString(), false)); ;
                selectListItems.Add(new SelectListItem(FuncionarioResource.ASSISTENTE_LABEL, ((int)CargoEnum.Assistente).ToString(), false));
                selectListItems.Add(new SelectListItem(FuncionarioResource.AUXILIAR_LABEL, ((int)CargoEnum.Auxiliar).ToString(), false));
            });

            return selectListItems;
        }

        #endregion

    }
}