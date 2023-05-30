using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecrutaPlus.Domain.Entities
{
    public abstract class Entity
    {
        [NotMapped]
        public ValidationResult ValidationResult { get; set; }
        public abstract bool IsValid();
    }
}
