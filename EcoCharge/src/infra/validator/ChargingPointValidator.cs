namespace EcoCharge.infra.validator;

using FluentValidation;
using EcoCharge.domain.model;

public class ChargingPointValidator : AbstractValidator<ChargingPoint>
{
    public ChargingPointValidator()
    {
        RuleFor(point => point.ChargingStationId)
            .NotEmpty().WithMessage("ChargingStationId é obrigatório.");

        RuleFor(point => point.ConnectorType)
            .MaximumLength(30).WithMessage("ConnectorType deve ter no máximo 30 caracteres.");

        RuleFor(point => point.ChargingSpeed)
            .GreaterThan(0).WithMessage("ChargingSpeed deve ser maior que zero.");

        RuleFor(point => point.Availability)
            .MaximumLength(20).WithMessage("Availability deve ter no máximo 20 caracteres.");
    }
}