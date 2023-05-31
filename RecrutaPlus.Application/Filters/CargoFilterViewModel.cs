using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RecrutaPlus.Application.Filters
{
    public class CargoFilterViewModel
    {
        [Display(Name = "Código")]
        public int? cargoId { get; set; }

        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Display(Name = "Descrição")]
        public string descricao { get; set; }

        //Default
        public DateTime? Cadastro { get; set; }
        public string CadastradoPor { get; set; }
        public DateTime? Edicao { get; set; }
        public string EditadoPor { get; set; }
        public long? VersionStamp { get; set; } //public byte[]? VersionStamp { get; set; }
        public Guid? GuidStamp { get; set; }
    }
}
