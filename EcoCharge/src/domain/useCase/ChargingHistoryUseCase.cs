using EcoCharge.domain.model;
using EcoCharge.domain.repository;
using EcoCharge.domain.useCase.dto;
using EcoCharge.domain.useCase.dtos;
using EcoCharge.infra.exception;

namespace EcoCharge.domain.useCase
{
    public class ChargingHistoryUseCase : IChargingHistoryUseCase
    {
        private readonly IChargingHistoryRepository _chargingHistoryRepository;

        public ChargingHistoryUseCase(IChargingHistoryRepository chargingHistoryRepository)
        {
            _chargingHistoryRepository = chargingHistoryRepository;
        }

        public ChargingHistory FindById(string id)
        {
            var chargingHistory = _chargingHistoryRepository.FindById(id);

            if (chargingHistory == null)
            {
                throw new NotFoundException($"ChargingHistory with ID {id} not found.");
            }

            return chargingHistory;
        }

        public void Create(ChargingHistory chargingHistory)
        {
            var persistedChargingHistory = _chargingHistoryRepository.FindById(chargingHistory.Id);

            if (persistedChargingHistory != null)
            {
                throw new AlreadyExistsException($"ChargingHistory with ID {chargingHistory.Id} already exists.");
            }

            _chargingHistoryRepository.Create(chargingHistory);
        }

        public ChargingHistory Update(string id, ChargingHistory chargingHistory)
        {
            var persistedChargingHistory = _chargingHistoryRepository.FindById(id);

            if (persistedChargingHistory == null)
            {
                throw new NotFoundException($"ChargingHistory with ID {id} not found.");
            }

            _chargingHistoryRepository.Update(id, chargingHistory);

            return chargingHistory;
        }

        public void Delete(string id)
        {
            var persistedChargingHistory = _chargingHistoryRepository.FindById(id);

            if (persistedChargingHistory == null)
            {
                throw new NotFoundException($"ChargingHistory with ID {id} not found.");
            }

            _chargingHistoryRepository.Delete(id);
        }
    }
}