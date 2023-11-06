using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecrutaPlus.Application.ViewModels
{
    public class FeriasFilter
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


        public virtual CargoFilter CargoFilter { get; set; }
        public virtual LoginFilter LoginFilter { get; set; }
        public virtual IEnumerable<CargoFilter> CargoViewModels { get; set; }

    }
}
