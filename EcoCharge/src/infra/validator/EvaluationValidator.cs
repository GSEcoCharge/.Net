namespace EcoCharge.infra.validator;

using FluentValidation;
using EcoCharge.domain.model;

public class EvaluationValidator : AbstractValidator<Evaluation>
{
    public EvaluationValidator()
    {
        RuleFor(evaluation => evaluation.UserId)
            .NotEmpty().WithMessage("UserId é obrigatório.");

        RuleFor(evaluation => evaluation.ChargingPostId)
            .NotEmpty().WithMessage("ChargingPostId é obrigatório.");

        RuleFor(evaluation => evaluation.Rating)
            .Matches(@"^[1-5]$").When(evaluation => !string.IsNullOrEmpty(evaluation.Rating))
            .WithMessage("Rating deve estar entre 1 e 5.");

        RuleFor(evaluation => evaluation.Comment)
            .MaximumLength(200).WithMessage("Comment deve ter no máximo 200 caracteres.");

        RuleFor(evaluation => evaluation.RatingDate)
            .Matches(@"^\d{4}-\d{2}-\d{2}$").When(evaluation => !string.IsNullOrEmpty(evaluation.RatingDate))
            .WithMessage("RatingDate deve estar no formato AAAA-MM-DD.");
    }
}