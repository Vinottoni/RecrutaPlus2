using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AutoMapper.Configuration.Annotations;
using RecrutaPlus.Domain.ValueObjects;

namespace RecrutaPlus.Application.ViewModels
{
    public class FuncionarioViewModel
    {
        [Display(Name = "Código")]
        public int FuncionarioId { get; set; }
        
        [Display(Name = "Código")]
        public int CargoId { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "RG")]
        public string RG { get; set; }

        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateOnly DataNascimento { get; set; }

        [Display(Name = "Gênero")]
        public int Genero { get; set; }

        [Display(Name = "CEP")]
        public string CEP { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Display(Name = "Educação")]
        public string Educacao { get; set; }

        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }

        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Display(Name = "Salário")]
        public decimal Salario { get; set; }

        //Default
        public DateTime Cadastro { get; set; }
        public string CadastradoPor { get; set; }
        public DateTime Edicao { get; set; }
        public string EditadoPor { get; set; }
        public long VersionStamp { get; set; } //public byte[]? VersionStamp { get; set; }
        public Guid GuidStamp { get; set; }

        [JsonIgnore]
        public virtual IList<CargoViewModel> CargoViewModels { get; set; }

        //Custom
        [Display(Name = "Valor por Hora")]
        public decimal ValorPorHora { get; set; }

        [Display(Name = "Quantidade de Horas por Mês")]
        public int QuantidadeHoraMes { get; set; }

        [Ignore]
        public decimal SalarioFinal
        {
            get
            {
                if (ValorPorHora > 0 && QuantidadeHoraMes > 0)
                {
                    return ValorPorHora * QuantidadeHoraMes;
                }
                else
                {
                    return 0;
                }
            }
            
        }

        [JsonIgnore]
        public string GeneroToString => GeneroValueObject.GetName(Genero);
        
        [JsonIgnore]
        public string CargoToString => CargoValueObject.GetName(CargoId);

    }
}
