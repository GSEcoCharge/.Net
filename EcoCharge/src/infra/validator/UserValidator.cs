namespace EcoCharge.infra.validator;

using FluentValidation;
using EcoCharge.domain.model;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user.Name)
            .NotEmpty().WithMessage("Name é obrigatório.")
            .Length(2, 50).WithMessage("Name deve ter entre 2 e 50 caracteres.");

        RuleFor(user => user.Email)
            .NotEmpty().WithMessage("Email é obrigatório.")
            .EmailAddress().WithMessage("Email deve ser válido.");

        RuleFor(user => user.Password)
            .NotEmpty().WithMessage("Password é obrigatório.")
            .MinimumLength(6).WithMessage("Password deve ter pelo menos 6 caracteres.");

        RuleFor(user => user.CreatedAt)
            .NotEmpty().WithMessage("CreatedAt é obrigatório.")
            .Matches(@"^\d{4}-\d{2}-\d{2}$").WithMessage("CreatedAt deve estar no formato AAAA-MM-DD.");

        RuleFor(user => user.LastLocation)
            .MaximumLength(100).WithMessage("LastLocation deve ter no máximo 100 caracteres.")
            .When(user => !string.IsNullOrEmpty(user.LastLocation));
    }
}