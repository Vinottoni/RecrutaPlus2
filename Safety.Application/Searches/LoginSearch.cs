using Safety.Application.Filters;
using Safety.Application.ViewModels;
using Safety.Domain.Constants;
using Safety.Domain.ValueObjects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Safety.Application.Searches
{
    public class LoginSearch
    {
        [JsonIgnore]
        public List<LoginViewModel> Itens { get; set; } = new List<LoginViewModel>();
        public LoginFilterViewModel Filter { get; set; }

        [Display(Name = "Carregar")]
        public bool HasFilter { get; set; } = DefaultConst.FILTER_HASFILTER_DEFAULT;
        public int TakeLast { get; set; } = DefaultConst.FILTER_TAKELAST_DEFAULT_ALL;
        public TakeLastEnum TakeLasts { get; set; }
    }
}
