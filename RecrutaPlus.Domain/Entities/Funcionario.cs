using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using RecrutaPlus.Domain.Validators;
using RecrutaPlus.Domain.ValueObjects;

namespace RecrutaPlus.Domain.Entities
{
    public class Funcionario : Entity
    {
        //public int EmployeeId { get; set; }

        public int FuncionarioId { get; set; }
        public int CargoId { get; set; }
        public int? FeriasId { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateOnly DataNascimento { get; set; }
        public int Genero { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public int Educacao { get; set; }
        public bool Ativo { get; set; }
        public string Estado { get; set; }
        public decimal Salario { get; set; }
        public decimal DiariaVA { get; set; }
        public decimal ValorPorHora { get; set; }
        public int QuantidadeHoraMes { get; set; }

        //novo
        public decimal SalarioLiquido { get; set; }
        public decimal INSS { get; set; }
        public decimal IRRF { get; set; }
        public decimal FGTS { get; set; }
        public int? Dependentes { get; set; }
        public decimal TotalDescontos { get; set; }

        //Default
        public DateTime Cadastro { get; set; }
        public string CadastradoPor { get; set; }
        public DateTime Edicao { get; set; }
        public string EditadoPor { get; set; }
        public long VersionStamp { get; set; } //public byte[]? VersionStamp { get; set; }
        [NotMapped]
        public Guid GuidStamp { get; set; }

        public virtual Cargo Cargo { get; set; }
        public virtual Ferias Ferias { get; set; }
        public virtual Login Login { get; set; }
        public virtual IEnumerable<Cargo> Cargos { get; set; }
        public virtual IEnumerable<Ferias> Feriass { get; set; }
        public virtual IEnumerable<Login> Logins { get; set; }

        public override bool IsValid()  //Aqui ainda tem refências para criar em Services
        {
            ValidationResult = new FuncionarioValidator().Validate(this);
            return ValidationResult.IsValid;
        }

        [JsonIgnore]
        public string CargoToString => CargoValueObject.GetName(CargoId);

    }
}
