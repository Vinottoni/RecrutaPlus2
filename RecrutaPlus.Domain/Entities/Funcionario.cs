using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecrutaPlus.Domain.Validators;

namespace RecrutaPlus.Domain.Entities
{
    public class Funcionario : Entity
    {
        //public int EmployeeId { get; set; }

        public int FuncionarioId { get; set; }

        public int CargoId { get; set; }

        public string Nome { get; set; }

        public string RG { get; set; }

        public string CPF { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public DateOnly DataNascimento { get; set; }

        public string Genero { get; set; }

        public string CEP { get; set; }

        public string Endereco { get; set; }

        public string Bairro { get; set; }

        public string Educacao { get; set; }

        public bool Ativo { get; set; }

        public string Estado { get; set; }


        //Default
        public DateTime Cadastro { get; set; }
        public string CadastradoPor { get; set; }
        public DateTime Edicao { get; set; }
        public string EditadoPor { get; set; }
        public long VersionStamp { get; set; } //public byte[]? VersionStamp { get; set; }
        [NotMapped]
        public Guid GuidStamp { get; set; }

        public virtual Cargo Cargo { get; set; }
        public virtual Login Login { get; set; }
        public virtual IEnumerable<Cargo> Cargos { get; set; }
        public virtual IEnumerable<Login> Logins { get; set; }

        public override bool IsValid()  //Aqui ainda tem refências para criar em Services
        {
            ValidationResult = new FuncionarioValidator().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
