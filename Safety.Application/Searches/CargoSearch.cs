using Safety.Application.Filters;
using Safety.Application.ViewModels;
using Safety.Domain.Constants;
using Safety.Domain.ValueObjects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Safety.Application.Searches
{
    public class CargoSearch
    {
        [JsonIgnore]
        public List<CargoViewModel> Itens { get; set; } = new List<CargoViewModel>();
        public CargoFilterViewModel Filter { get; set; }

        [Display(Name = "Carregar")]
        public bool HasFilter { get; set; } = DefaultConst.FILTER_HASFILTER_DEFAULT;
        public int TakeLast { get; set; } = DefaultConst.FILTER_TAKELAST_DEFAULT_ALL;
        public TakeLastEnum TakeLasts { get; set; }
    }
}
