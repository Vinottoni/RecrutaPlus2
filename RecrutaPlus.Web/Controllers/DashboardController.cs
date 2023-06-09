using RecrutaPlus.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
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

            string connectionString = "server=localhost;database=recrutamais2;User Id=root;password=123456";
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                // Quantidade total de funcionários
                funcionarioSearch.TotalFuncionarios = GetQuantidadeTotalFuncionarios(connection);

                // Funcionários ativos
                funcionarioSearch.FuncionariosAtivos = GetQuantidadeFuncionariosAtivos(connection);

                // Funcionários desativados
                funcionarioSearch.FuncionariosDesativados = GetQuantidadeFuncionariosDesativados(connection);

                // Funcionários mais recentes cadastrados
                //int quantidadeFuncionariosRecentes;
                //var funcionariosRecentes = GetFuncionariosMaisRecentes(connection, 5, out quantidadeFuncionariosRecentes);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao conectar ao banco de dados: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }


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

        static int GetQuantidadeTotalFuncionarios(SqlConnection connection)
        {
            string query = "SELECT COUNT(*) FROM funcionarios";
            SqlCommand command = new SqlCommand(query, connection);
            return (int)command.ExecuteScalar();
        }

        static int GetQuantidadeFuncionariosAtivos(SqlConnection connection)
        {
            string query = "SELECT COUNT(*) FROM funcionarios WHERE Ativo = 'S'";
            SqlCommand command = new SqlCommand(query, connection);
            return (int)command.ExecuteScalar();
        }

        static int GetQuantidadeFuncionariosDesativados(SqlConnection connection)
        {
            string query = "SELECT COUNT(*) FROM funcionarios WHERE Ativo = 'N'";
            SqlCommand command = new SqlCommand(query, connection);
            return (int)command.ExecuteScalar();
        }

        //static List<Funcionario> GetFuncionariosMaisRecentes(SqlConnection connection, int quantidade, out int quantidadeTotal)
        //{
        //    string query = "SELECT TOP " + quantidade + " FuncionarioId, Nome, Cadastro FROM funcionarios ORDER BY DataCadastro DESC";
        //    SqlCommand command = new SqlCommand(query, connection);
        //    SqlDataReader reader = command.ExecuteReader();

        //    List<Funcionario> funcionarios = new List<Funcionario>();

        //    while (reader.Read())
        //    {
        //        int id = reader.GetInt32(0);
        //        string nome = reader.GetString(1);
        //        DateTime dataCadastro = reader.GetDateTime(2);

        //        //Funcionario funcionario = new Funcionario(id, nome, dataCadastro);
        //        //funcionarios.Add(funcionario);
        //    }

        //    reader.Close();

        //    // Obter a quantidade total de funcionários
        //    string queryTotal = "SELECT COUNT(*) FROM funcionarios";
        //    SqlCommand commandTotal = new SqlCommand(queryTotal, connection);
        //    quantidadeTotal = (int)commandTotal.ExecuteScalar();

        //    return funcionarios;
        //}

    }
}