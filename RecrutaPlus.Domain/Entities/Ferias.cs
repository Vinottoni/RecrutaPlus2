using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using RecrutaPlus.Domain.Validators;
using RecrutaPlus.Domain.ValueObjects;

namespace RecrutaPlus.Domain.Entities
{
    public class Ferias : Entity
    {
        public int FeriasId { get; set; }
        public int FuncionarioId { get; set; }
        public decimal ValorHoraExtra { get; set; }
        public int Dependentes { get; set; }
        public int DiasFerias { get; set; }
        public bool AbonoPecuniario { get; set; }
        public bool DecimoTerceiro { get; set; }

        //Default
        public DateTime Cadastro { get; set; }
        public string CadastradoPor { get; set; }
        public DateTime Edicao { get; set; }
        public string EditadoPor { get; set; }
        public long VersionStamp { get; set; } //public byte[]? VersionStamp { get; set; }
        [NotMapped]
        public Guid GuidStamp { get; set; }

        public virtual Funcionario Funcionario { get; set; }
        public virtual Login Login { get; set; }
        public virtual IEnumerable<Cargo> Cargos { get; set; }
        public virtual IEnumerable<Funcionario> Funcionarios { get; set; }
        public virtual IEnumerable<Login> Logins { get; set; }

        public override bool IsValid()  //Aqui ainda tem refências para criar em Services
        {
            ValidationResult = new FeriasValidator().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
