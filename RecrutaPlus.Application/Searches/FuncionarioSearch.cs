using RecrutaPlus.Application.Filters;
using RecrutaPlus.Application.ViewModels;
using RecrutaPlus.Domain.Constants;
using RecrutaPlus.Domain.ValueObjects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RecrutaPlus.Application.Searches
{
    public class FuncionarioSearch
    {
        [JsonIgnore]
        public List<FuncionarioViewModel> Itens { get; set; } = new List<FuncionarioViewModel>();
        public FuncionarioFilterViewModel Filter { get; set; }
        public FuncionarioViewModel FuncionarioViewModels { get; set; }

        [JsonIgnore]
        public virtual IList<FuncionarioViewModel> Funcionarios { get; set; }

        [Display(Name = "Carregar")]
        public bool HasFilter { get; set; } = DefaultConst.FILTER_HASFILTER_DEFAULT;
        public int TakeLast { get; set; } = DefaultConst.FILTER_TAKELAST_DEFAULT_ALL;
        public TakeLastEnum TakeLasts { get; set; }
    }
}
