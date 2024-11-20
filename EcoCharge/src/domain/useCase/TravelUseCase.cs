using EcoCharge.domain.model;
using EcoCharge.domain.repository;
using EcoCharge.domain.useCase.dto;
using EcoCharge.domain.useCase.dtos;
using EcoCharge.infra.exception;

namespace EcoCharge.domain.useCase
{
    public class TravelUseCase : ITravelUseCase
    {
        private readonly ITravelRepository _travelRepository;

        public TravelUseCase(ITravelRepository travelRepository)
        {
            _travelRepository = travelRepository;
        }

        public Travel FindById(string id)
        {
            var travel = _travelRepository.FindById(id);

            if (travel == null)
            {
                throw new NotFoundException($"Travel with ID {id} not found.");
            }

            return travel;
        }

        public void Create(Travel travel)
        {
            var persistedTravel = _travelRepository.FindById(travel.Id);

            if (persistedTravel != null)
            {
                throw new AlreadyExistsException($"Travel with ID {travel.Id} already exists.");
            }

            _travelRepository.Create(travel);
        }

        public Travel Update(string id, Travel travel)
        {
            var persistedTravel = _travelRepository.FindById(id);

            if (persistedTravel == null)
            {
                throw new NotFoundException($"Travel with ID {id} not found.");
            }

            _travelRepository.Update(id, travel);

            return travel;
        }

        public void Delete(string id)
        {
            var persistedTravel = _travelRepository.FindById(id);

            if (persistedTravel == null)
            {
                throw new NotFoundException($"Travel with ID {id} not found.");
            }

            _travelRepository.Delete(id);
        }
    }
}