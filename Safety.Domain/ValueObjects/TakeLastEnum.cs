using System.ComponentModel.DataAnnotations;

namespace Safety.Domain.ValueObjects
{
    public enum TakeLastEnum
    {
        [Display(Name = "10 registros")]
        Row10 = 10,

        [Display(Name = "25 registros")]
        Row25 = 25,

        [Display(Name = "50 registros")]
        Row50 = 50,

        [Display(Name = "100 registros")]
        Row100 = 100,

        [Display(Name = "Todos os registros")]
        RowAll = int.MaxValue
    }
}
