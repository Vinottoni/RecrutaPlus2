using FluentValidation;
using Safety.Domain.Entities;

namespace Safety.Domain.Validators
{
    public class LoginValidator : AbstractValidator<Login>
    {
        public LoginValidator() 
        { 

        }
    }
}
