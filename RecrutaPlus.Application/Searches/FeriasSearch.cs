using Safety.Application.Filters;
using Safety.Application.ViewModels;
using Safety.Domain.Constants;
using Safety.Domain.ValueObjects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Safety.Application.Searches
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
