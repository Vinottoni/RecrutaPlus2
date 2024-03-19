using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Safety.Application.ViewModels
{
    public class CargoFilter
    {
        public int? CargoId { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }


        //Default
        public DateTime? Cadastro { get; set; }
        public string CadastradoPor { get; set; }
        public DateTime? Edicao { get; set; }
        public string EditadoPor { get; set; }
        public long? VersionStamp { get; set; } //public byte[]? VersionStamp { get; set; }
        public Guid? GuidStamp { get; set; }
    }
}
