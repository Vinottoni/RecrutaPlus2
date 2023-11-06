using RecrutaPlus.Application.Filters;
using RecrutaPlus.Application.ViewModels;
using RecrutaPlus.Domain.Constants;
using RecrutaPlus.Domain.ValueObjects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RecrutaPlus.Application.Searches
{
    public class FeriasSearch
    {
        [JsonIgnore]
        public List<FeriasViewModel> Itens { get; set; } = new List<FeriasViewModel>();
        public FeriasFilterViewModel Filter { get; set; }
        public FeriasViewModel FeriasViewModel { get; set; }
        public DashboardViewModel DashboardViewModel { get; set; }

        [JsonIgnore]
        public virtual IList<FeriasViewModel> Feriass { get; set; }

        [Display(Name = "Carregar")]
        public bool HasFilter { get; set; } = DefaultConst.FILTER_HASFILTER_DEFAULT;
        public int TakeLast { get; set; } = DefaultConst.FILTER_TAKELAST_DEFAULT_ALL;
        public TakeLastEnum TakeLasts { get; set; }
    }
}
