using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecrutaPlus.Domain.Validators;

namespace RecrutaPlus.Domain.Entities
{
    public class Login : Entity
    {
        public int UsuarioId { get; set; }

        public int FuncionarioId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }


        //Default
        public DateTime Cadastro { get; set; }
        public string CadastradoPor { get; set; }
        public DateTime Edicao { get; set; }
        public string EditadoPor { get; set; }
        public long VersionStamp { get; set; } //public byte[]? VersionStamp { get; set; }
        [NotMapped]
        public Guid GuidStamp { get; set; }

        public virtual Funcionario Funcionario { get; set; }
        public virtual IEnumerable<Funcionario> Funcionarios { get; set; }

        public override bool IsValid() //Aqui ainda tem refências para criar em Services
        {
            ValidationResult = new LoginValidator().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
