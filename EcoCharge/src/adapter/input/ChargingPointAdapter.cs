using FluentValidation;
using EcoCharge.domain.model;
using EcoCharge.domain.useCase.dto;
using EcoCharge.adapter.input.dtos;
using EcoCharge.domain.useCase.dtos;
using EcoCharge.infra.exception;

namespace EcoCharge.adapter.input
{
    public class ChargingPointAdapter : IChargingPointAdapter
    {
        private readonly IChargingPointUseCase _chargingPointUseCase;
        private readonly IValidator<ChargingPoint> _chargingPointValidator;

        public ChargingPointAdapter(IChargingPointUseCase chargingPointUseCase, IValidator<ChargingPoint> chargingPointValidator)
        {
            _chargingPointUseCase = chargingPointUseCase;
            _chargingPointValidator = chargingPointValidator;
        }

        public ChargingPoint FindById(string id)
        {
            var chargingPoint = _chargingPointUseCase.FindById(id);
    
            if (chargingPoint == null)
            {
                throw new NotFoundException($"ChargingPoint with ID {id} not found.");
            }

            return chargingPoint;
        }

        public void Create(ChargingPoint chargingPoint)
        {
            ValidateChargingPoint(chargingPoint);
            _chargingPointUseCase.Create(chargingPoint);
        }

        public ChargingPoint Update(string id, ChargingPoint chargingPoint)
        {
            ValidateChargingPoint(chargingPoint);
            return _chargingPointUseCase.Update(id, chargingPoint);
        }

        public void Delete(string id)
        {
            _chargingPointUseCase.Delete(id);
        }

        private void ValidateChargingPoint(ChargingPoint chargingPoint)
        {
            var validationResult = _chargingPointValidator.Validate(chargingPoint);

            if (!validationResult.IsValid)
            {
                throw new InvalidException(
                    string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))
                );
            }
        }
    }
}
