using EcoCharge.domain.model;
using EcoCharge.domain.repository;
using EcoCharge.domain.useCase.dto;
using EcoCharge.domain.useCase.dtos;
using EcoCharge.infra.exception;

namespace EcoCharge.domain.useCase
{
    public class ChargingPointUseCase : IChargingPointUseCase
    {
        private readonly IChargingPointRepository _chargingPointRepository;

        public ChargingPointUseCase(IChargingPointRepository chargingPointRepository)
        {
            _chargingPointRepository = chargingPointRepository;
        }

        public ChargingPoint FindById(int id)
        {
            var chargingPoint = _chargingPointRepository.FindById(id);

            if (chargingPoint == null)
            {
                throw new NotFoundException($"ChargingPoint with ID {id} not found.");
            }

            return chargingPoint;
        }

        public void Create(ChargingPoint chargingPoint)
        {
            var persistedChargingPoint = _chargingPointRepository.FindById(chargingPoint.Id);

            if (persistedChargingPoint != null)
            {
                throw new AlreadyExistsException($"ChargingPoint with ID {chargingPoint.Id} already exists.");
            }

            _chargingPointRepository.Create(chargingPoint);
        }

        public ChargingPoint Update(int id, ChargingPoint chargingPoint)
        {
            var persistedChargingPoint = _chargingPointRepository.FindById(id);

            if (persistedChargingPoint == null)
            {
                throw new NotFoundException($"ChargingPoint with ID {id} not found.");
            }

            _chargingPointRepository.Update(id, chargingPoint);

            return chargingPoint;
        }

        public void Delete(int id)
        {
            var persistedChargingPoint = _chargingPointRepository.FindById(id);

            if (persistedChargingPoint == null)
            {
                throw new NotFoundException($"ChargingPoint with ID {id} not found.");
            }

            _chargingPointRepository.Delete(id);
        }
    }
}