using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RecrutaPlus.Application.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Código")]
        public int UsuarioId { get; set; }

        [Display(Name = "Email")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        //Default
        public DateTime Cadastro { get; set; }
        public string CadastradoPor { get; set; }
        public DateTime Edicao { get; set; }
        public string EditadoPor { get; set; }
        public long VersionStamp { get; set; } //public byte[]? VersionStamp { get; set; }
        public Guid GuidStamp { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<FuncionarioViewModel> Funcionarios { get; set; }

        public FuncionarioViewModel funcionario { get; set; }

        //custom

        public bool SenhaValida(string senha)
        {
            return Password == senha;
        }

        //public string emailFuncionario
        //{
        //    get
        //    {
        //        return funcionario.Email;
        //    }
        //}
    }
}
