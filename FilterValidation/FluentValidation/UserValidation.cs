using FilterValidation.Dto_s;
using FilterValidation.Entities;
using FluentValidation;

namespace FilterValidation.FluentValidation
{
    public class UserValidation:AbstractValidator<UserDto>
    {
        public UserValidation()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(4).MaximumLength(8).WithMessage("no extixt name");
        }
    }
}
