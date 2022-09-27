using DemoRefit.Models;
using FluentValidation;

namespace DemoRefit.Validation
{
    public class UserValidation : AbstractValidator<CreateUserRequest>
    {
        public UserValidation()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage(string.Format(MessageError.NotEmpty, "Username"));
            RuleFor(x => x.Username).MaximumLength(50).WithMessage(string.Format(MessageError.Length, "Username"));

            RuleFor(x => x.Password).NotEmpty().WithMessage(string.Format(MessageError.NotEmpty, "Password"));
            RuleFor(x => x.Password).MaximumLength(50).WithMessage(string.Format(MessageError.Length, "Password"));

            RuleFor(x => x.Email).NotEmpty().WithMessage(string.Format(MessageError.NotEmpty, "Email"));
            RuleFor(x => x.Email).MaximumLength(200).WithMessage(string.Format(MessageError.Length, "Email"));

            RuleFor(x => x.FirstName).NotEmpty().WithMessage(string.Format(MessageError.NotEmpty, "FirstName"));
            RuleFor(x => x.FirstName).MaximumLength(50).WithMessage(string.Format(MessageError.Length, "FirstName"));

            RuleFor(x => x.LastName).NotEmpty().WithMessage(string.Format(MessageError.NotEmpty, "LastName"));
            RuleFor(x => x.LastName).MaximumLength(50).WithMessage(string.Format(MessageError.Length, "LastName"));

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage(string.Format(MessageError.NotEmpty, "PhoneNumber"));
            RuleFor(x => x.PhoneNumber).MaximumLength(15).WithMessage(string.Format(MessageError.Length, "PhoneNumber"));

            RuleFor(x => x.Address).NotEmpty().WithMessage(string.Format(MessageError.NotEmpty, "Address"));
            RuleFor(x => x.Address).MaximumLength(255).WithMessage(string.Format(MessageError.Length, "Address"));

        }
    }
}
