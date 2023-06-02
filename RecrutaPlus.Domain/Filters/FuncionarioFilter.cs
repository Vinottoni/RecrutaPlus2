using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace RecrutaPlus.Application.ViewModels
{
    public class FuncionarioFilter
    {
        public int? FuncionarioId { get; set; }

        public int? CargoId { get; set; }

        public string Nome { get; set; }

        public string RG { get; set; }

        public string CPF { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public DateOnly? DataNascimento { get; set; }

        public int? Genero { get; set; }

        public string CEP { get; set; }

        public string Endereco { get; set; }

        public string Bairro { get; set; }

        public string Educacao { get; set; }

        public bool? Ativo { get; set; }

        public string Estado { get; set; }

        public decimal? Salario { get; set; }

        //Default
        public DateTime? Cadastro { get; set; }
        public string CadastradoPor { get; set; }
        public DateTime? Edicao { get; set; }
        public string EditadoPor { get; set; }
        public long? VersionStamp { get; set; } //public byte[]? VersionStamp { get; set; }
        public Guid? GuidStamp { get; set; }


        public virtual CargoFilter CargoFilter { get; set; }
        public virtual LoginFilter LoginFilter { get; set; }
        public virtual IEnumerable<CargoFilter> CargoViewModels { get; set; }

    }
}
