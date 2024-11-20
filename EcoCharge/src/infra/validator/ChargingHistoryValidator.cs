namespace EcoCharge.infra.validator;

using FluentValidation;
using EcoCharge.domain.model;

public class ChargingHistoryValidator : AbstractValidator<ChargingHistory>
{
    public ChargingHistoryValidator()
    {
        RuleFor(history => history.UserId)
            .NotEmpty().WithMessage("UserId é obrigatório.");

        RuleFor(history => history.ChargingPointId)
            .NotEmpty().WithMessage("ChargingPointId é obrigatório.");

        RuleFor(history => history.ChargingHistoryDate)
            .Matches(@"^\d{4}-\d{2}-\d{2}$").When(history => !string.IsNullOrEmpty(history.ChargingHistoryDate))
            .WithMessage("Date deve estar no formato AAAA-MM-DD.");

        RuleFor(history => history.ConsumedEnergy)
            .Matches(@"^\d+(\.\d{1,2})?$").When(history => !string.IsNullOrEmpty(history.ConsumedEnergy))
            .WithMessage("ConsumedEnergy deve ser um número positivo.");

        RuleFor(history => history.AvoidedEmissions)
            .MaximumLength(50).WithMessage("AvoidedEmissions deve ter no máximo 50 caracteres.");
    }
}