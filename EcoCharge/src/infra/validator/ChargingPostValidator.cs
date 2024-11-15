namespace EcoCharge.infra.validator;

using FluentValidation;
using EcoCharge.domain.model;

public class ChargingPostValidator : AbstractValidator<ChargingPost>
{
    public ChargingPostValidator()
    {
        RuleFor(post => post.Name)
            .NotEmpty().WithMessage("Name é obrigatório.")
            .MaximumLength(50).WithMessage("Name deve ter no máximo 50 caracteres.");

        RuleFor(post => post.Latitude)
            .InclusiveBetween(-90, 90).WithMessage("Latitude deve estar entre -90 e 90.");

        RuleFor(post => post.Longitude)
            .InclusiveBetween(-180, 180).WithMessage("Longitude deve estar entre -180 e 180.");

        RuleFor(post => post.Address)
            .MaximumLength(200).WithMessage("Address deve ter no máximo 200 caracteres.");

        RuleFor(post => post.OpenHours)
            .MaximumLength(50).WithMessage("OpenHours deve ter no máximo 50 caracteres.");

        RuleFor(post => post.PaymentMethods)
            .MaximumLength(100).WithMessage("PaymentMethods deve ter no máximo 100 caracteres.");
    }
}