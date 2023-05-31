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
        [JsonIgnore]
        public List<FuncionarioViewModel> Itens { get; set; } = new List<FuncionarioViewModel>();
    }
}
