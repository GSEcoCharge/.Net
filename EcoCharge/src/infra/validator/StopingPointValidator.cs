namespace EcoCharge.infra.validator;

using FluentValidation;
using EcoCharge.domain.model;

public class StopingPointValidator : AbstractValidator<StopingPoint>
{
    public StopingPointValidator()
    {
        RuleFor(point => point.TravelId)
            .NotEmpty().WithMessage("TravelId é obrigatório.");

        RuleFor(point => point.ChargingPointId)
            .NotEmpty().WithMessage("ChargingPointId é obrigatório.");

        RuleFor(point => point.Order)
            .Matches(@"^\d+$").When(point => !string.IsNullOrEmpty(point.Order))
            .WithMessage("Order deve ser um número.");
    }
}