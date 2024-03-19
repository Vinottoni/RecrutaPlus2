using Safety.Application.Filters;
using Safety.Application.ViewModels;
using Safety.Domain.Constants;
using Safety.Domain.ValueObjects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Safety.Application.Searches
{
    public class FuncionarioSearch
    {
        [JsonIgnore]
        public List<FuncionarioViewModel> Itens { get; set; } = new List<FuncionarioViewModel>();
        public FuncionarioFilterViewModel Filter { get; set; }
        public FuncionarioViewModel FuncionarioViewModel { get; set; }
        public DashboardViewModel DashboardViewModel { get; set; }

        [JsonIgnore]
        public virtual IList<FuncionarioViewModel> Funcionarios { get; set; }

        [Display(Name = "Carregar")]
        public bool HasFilter { get; set; } = DefaultConst.FILTER_HASFILTER_DEFAULT;
        public int TakeLast { get; set; } = DefaultConst.FILTER_TAKELAST_DEFAULT_ALL;
        public TakeLastEnum TakeLasts { get; set; }
    }
}
