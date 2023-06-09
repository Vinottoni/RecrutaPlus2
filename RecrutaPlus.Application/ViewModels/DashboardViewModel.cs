using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RecrutaPlus.Application.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalFuncionarios { get; set; }
        public int FuncionariosAtivos { get; set; }
        public int FuncionariosDesativados { get; set; }
        public int FuncionariosRecentes { get; set; }
    }
}
