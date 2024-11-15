namespace EcoCharge.infra.validator;

using FluentValidation;
using EcoCharge.domain.model;

public class TravelValidator : AbstractValidator<Travel>
{
    public TravelValidator()
    {
        RuleFor(travel => travel.UserId)
            .GreaterThan(0).WithMessage("UserId deve ser maior que zero.");

        RuleFor(travel => travel.StartPoint)
            .NotEmpty().WithMessage("StartPoint é obrigatório.")
            .MaximumLength(100).WithMessage("StartPoint deve ter no máximo 100 caracteres.");

        RuleFor(travel => travel.EndPoint)
            .NotEmpty().WithMessage("EndPoint é obrigatório.")
            .MaximumLength(100).WithMessage("EndPoint deve ter no máximo 100 caracteres.");

        RuleFor(travel => travel.RemainingAutonomy)
            .GreaterThanOrEqualTo(0).WithMessage("RemainingAutonomy deve ser maior ou igual a zero.");

        RuleFor(travel => travel.CreatedAt)
            .NotEmpty().WithMessage("CreatedAt é obrigatório.")
            .Matches(@"^\d{4}-\d{2}-\d{2}$").WithMessage("CreatedAt deve estar no formato AAAA-MM-DD.");
    }
}