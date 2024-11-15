using FluentValidation;
using EcoCharge.domain.model;
using EcoCharge.domain.useCase.dto;
using EcoCharge.adapter.input.dtos;
using EcoCharge.domain.useCase.dtos;
using EcoCharge.infra.exception;

namespace EcoCharge.adapter.input
{
    public class TravelAdapter : ITravelAdapter
    {
        private readonly ITravelUseCase _travelUseCase;
        private readonly IValidator<Travel> _travelValidator;

        public TravelAdapter(ITravelUseCase travelUseCase, IValidator<Travel> travelValidator)
        {
            _travelUseCase = travelUseCase;
            _travelValidator = travelValidator;
        }

        public Travel FindById(int id)
        {
            var travel = _travelUseCase.FindById(id);
    
            if (travel == null)
            {
                throw new NotFoundException($"Travel with ID {id} not found.");
            }

            return travel;
        }

        public void Create(Travel travel)
        {
            ValidateTravel(travel);
            _travelUseCase.Create(travel);
        }

        public Travel Update(int id, Travel travel)
        {
            ValidateTravel(travel);
            return _travelUseCase.Update(id, travel);
        }

        public void Delete(int id)
        {
            _travelUseCase.Delete(id);
        }

        private void ValidateTravel(Travel travel)
        {
            var validationResult = _travelValidator.Validate(travel);

            if (!validationResult.IsValid)
            {
                throw new InvalidException(
                    string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))
                );
            }
        }
    }
}
