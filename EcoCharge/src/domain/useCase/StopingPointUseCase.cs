using EcoCharge.domain.model;
using EcoCharge.domain.repository;
using EcoCharge.domain.useCase.dto;
using EcoCharge.domain.useCase.dtos;
using EcoCharge.infra.exception;

namespace EcoCharge.domain.useCase
{
    public class StopingPointUseCase : IStopingPointUseCase
    {
        private readonly IStopingPointRepository _chargingPointRepository;

        public StopingPointUseCase(IStopingPointRepository chargingPointRepository)
        {
            _chargingPointRepository = chargingPointRepository;
        }

        public StopingPoint FindById(int id)
        {
            var chargingPoint = _chargingPointRepository.FindById(id);

            if (chargingPoint == null)
            {
                throw new NotFoundException($"StopingPoint with ID {id} not found.");
            }

            return chargingPoint;
        }

        public void Create(StopingPoint chargingPoint)
        {
            var persistedStopingPoint = _chargingPointRepository.FindById(chargingPoint.Id);

            if (persistedStopingPoint != null)
            {
                throw new AlreadyExistsException($"StopingPoint with ID {chargingPoint.Id} already exists.");
            }

            _chargingPointRepository.Create(chargingPoint);
        }

        public StopingPoint Update(int id, StopingPoint chargingPoint)
        {
            var persistedStopingPoint = _chargingPointRepository.FindById(id);

            if (persistedStopingPoint == null)
            {
                throw new NotFoundException($"StopingPoint with ID {id} not found.");
            }

            _chargingPointRepository.Update(id, chargingPoint);

            return chargingPoint;
        }

        public void Delete(int id)
        {
            var persistedStopingPoint = _chargingPointRepository.FindById(id);

            if (persistedStopingPoint == null)
            {
                throw new NotFoundException($"StopingPoint with ID {id} not found.");
            }

            _chargingPointRepository.Delete(id);
        }
    }
}