using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Safety.Domain.Validators;

namespace Safety.Domain.Entities
{
    public class Cargo : Entity
    {
        //public int OfficeId { get; set; } // assim já deve funcionar blz blz vou ver aqui testa ai e se nao conseguir depois das  18 vc chama ou amanha blz blz

        public int CargoId { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }


        //Default
        public DateTime Cadastro { get; set; }
        public string CadastradoPor { get; set; }
        public DateTime Edicao { get; set; }
        public string EditadoPor { get; set; }
        public long VersionStamp { get; set; } //public byte[]? VersionStamp { get; set; }
        [NotMapped]
        public Guid GuidStamp { get; set; }

        public virtual IList<Funcionario> Funcionarios { get; set; }

        public override bool IsValid() //Aqui ainda tem refências para criar em Services
        {
            ValidationResult = new CargoValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
