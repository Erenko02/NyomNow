namespace NyomNow.NyomNow.Api.Validation
{
    using FluentValidation;
    using NyomNow.Api.Models;

    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(o => o.UserId).NotEmpty().WithMessage("UserId is required");
            RuleFor(o => o.RestaurantId).NotEmpty().WithMessage("RestaurantId is required");
            RuleFor(o => o.MenuItems).NotEmpty().WithMessage("At least one menu item is required");
        }
    }
}