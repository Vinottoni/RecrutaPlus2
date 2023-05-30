using RecrutaPlus.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RecrutaPlus.Application.Filters
{
    public class FuncionarioFilterViewModel
    {
        [Display(Name = "Código")]
        public int? funcionarioId { get; set; }

        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Display(Name = "RG")]
        public string rg { get; set; }

        [Display(Name = "CPF")]
        public string cpf { get; set; }

        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Telefone")]
        public string telefone { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateOnly? dataNascimento { get; set; }

        [Display(Name = "Gênero")]
        public string genero { get; set; }

        [Display(Name = "CEP")]
        public string cep { get; set; }

        [Display(Name = "Endereço")]
        public string endereco { get; set; }

        [Display(Name = "Bairro")]
        public string bairro { get; set; }

        [Display(Name = "Educação")]
        public string educacao { get; set; }

        [Display(Name = "Status")]
        public string status { get; set; }

        //Default
        public DateTime? Cadastro { get; set; }
        public string CadastradoPor { get; set; }
        public DateTime? Edicao { get; set; }
        public string EditadoPor { get; set; }
        public long? VersionStamp { get; set; } //public byte[]? VersionStamp { get; set; }
        public Guid? GuidStamp { get; set; }


        public virtual IEnumerable<CargoViewModel> CargoViewModels { get; set; }
    }
}
