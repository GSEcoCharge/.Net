namespace EcoCharge.infra.validator;

using FluentValidation;
using domain.model;

public class VehicleValidator : AbstractValidator<Vehicle>
{
    public VehicleValidator()
    {
        RuleFor(vehicle => vehicle.Brand)
            .NotEmpty().WithMessage("Brand é obrigatório.")
            .Length(2, 50).WithMessage("Brand deve ter entre 2 e 50 caracteres.");

        RuleFor(vehicle => vehicle.Model)
            .NotEmpty().WithMessage("Model é obrigatório.")
            .Length(2, 50).WithMessage("Model deve ter entre 2 e 50 caracteres.");

        RuleFor(vehicle => vehicle.VehicleYear)
            .Matches(@"^\d{4}$").When(vehicle => !string.IsNullOrEmpty(vehicle.VehicleYear))
            .WithMessage("Year deve ser um ano válido com 4 dígitos.");

        RuleFor(vehicle => vehicle.Autonomy)
            .Matches(@"^\d+(\.\d{1,2})?$").When(vehicle => !string.IsNullOrEmpty(vehicle.Autonomy))
            .WithMessage("Autonomy deve ser um número positivo.");

        RuleFor(vehicle => vehicle.ConnectorType)
            .MaximumLength(30).When(vehicle => !string.IsNullOrEmpty(vehicle.ConnectorType))
            .WithMessage("ConnectorType deve ter no máximo 30 caracteres."); 
    }
}