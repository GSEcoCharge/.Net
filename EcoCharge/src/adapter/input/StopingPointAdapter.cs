using FluentValidation;
using EcoCharge.domain.model;
using EcoCharge.domain.useCase.dto;
using EcoCharge.adapter.input.dtos;
using EcoCharge.domain.useCase.dtos;
using EcoCharge.infra.exception;

namespace EcoCharge.adapter.input
{
    public class StopingPointAdapter : IStopingPointAdapter
    {
        private readonly IStopingPointUseCase _stopingPointUseCase;
        private readonly IValidator<StopingPoint> _stopingPointValidator;

        public StopingPointAdapter(IStopingPointUseCase stopingPointUseCase, IValidator<StopingPoint> stopingPointValidator)
        {
            _stopingPointUseCase = stopingPointUseCase;
            _stopingPointValidator = stopingPointValidator;
        }

        public StopingPoint FindById(string id)
        {
            var stopingPoint = _stopingPointUseCase.FindById(id);
    
            if (stopingPoint == null)
            {
                throw new NotFoundException($"StopingPoint with ID {id} not found.");
            }

            return stopingPoint;
        }

        public void Create(StopingPoint stopingPoint)
        {
            ValidateStopingPoint(stopingPoint);
            _stopingPointUseCase.Create(stopingPoint);
        }

        public StopingPoint Update(string id, StopingPoint stopingPoint)
        {
            ValidateStopingPoint(stopingPoint);
            return _stopingPointUseCase.Update(id, stopingPoint);
        }

        public void Delete(string id)
        {
            _stopingPointUseCase.Delete(id);
        }

        private void ValidateStopingPoint(StopingPoint stopingPoint)
        {
            var validationResult = _stopingPointValidator.Validate(stopingPoint);

            if (!validationResult.IsValid)
            {
                throw new InvalidException(
                    string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))
                );
            }
        }
    }
}
