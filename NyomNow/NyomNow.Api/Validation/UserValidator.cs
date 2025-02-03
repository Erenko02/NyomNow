namespace NyomNow.NyomNow.Api.Validation
{
    using FluentValidation;
    using NyomNow.Api.Models;

    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(u => u.Email).EmailAddress().WithMessage("Invalid email format");
        }
    }
}