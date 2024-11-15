namespace EcoCharge.infra.validator;

using FluentValidation;
using EcoCharge.domain.model;

public class BookingValidator : AbstractValidator<Booking>
{
    public BookingValidator()
    {
        RuleFor(booking => booking.UserId)
            .NotEmpty().WithMessage("UserId é obrigatório.");

        RuleFor(booking => booking.ChargingPointId)
            .NotEmpty().WithMessage("ChargingPointId é obrigatório.");

        RuleFor(booking => booking.Date)
            .Matches(@"^\d{4}-\d{2}-\d{2}$").When(booking => !string.IsNullOrEmpty(booking.Date))
            .WithMessage("Date deve estar no formato AAAA-MM-DD.");

        RuleFor(booking => booking.Status)
            .MaximumLength(20).WithMessage("Status deve ter no máximo 20 caracteres.");
    }
}