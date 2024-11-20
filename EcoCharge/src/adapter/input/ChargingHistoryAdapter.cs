using FluentValidation;
using EcoCharge.domain.model;
using EcoCharge.domain.useCase.dto;
using EcoCharge.adapter.input.dtos;
using EcoCharge.domain.useCase.dtos;
using EcoCharge.infra.exception;

namespace EcoCharge.adapter.input
{
    public class ChargingHistoryAdapter : IChargingHistoryAdapter
    {
        private readonly IChargingHistoryUseCase _chargingHistoryUseCase;
        private readonly IValidator<ChargingHistory> _chargingHistoryValidator;

        public ChargingHistoryAdapter(IChargingHistoryUseCase chargingHistoryUseCase, IValidator<ChargingHistory> chargingHistoryValidator)
        {
            _chargingHistoryUseCase = chargingHistoryUseCase;
            _chargingHistoryValidator = chargingHistoryValidator;
        }

        public ChargingHistory FindById(string id)
        {
            var chargingHistory = _chargingHistoryUseCase.FindById(id);
    
            if (chargingHistory == null)
            {
                throw new NotFoundException($"ChargingHistory with ID {id} not found.");
            }

            return chargingHistory;
        }

        public void Create(ChargingHistory chargingHistory)
        {
            ValidateChargingHistory(chargingHistory);
            _chargingHistoryUseCase.Create(chargingHistory);
        }

        public ChargingHistory Update(string id, ChargingHistory chargingHistory)
        {
            ValidateChargingHistory(chargingHistory);
            return _chargingHistoryUseCase.Update(id, chargingHistory);
        }

        public void Delete(string id)
        {
            _chargingHistoryUseCase.Delete(id);
        }

        private void ValidateChargingHistory(ChargingHistory chargingHistory)
        {
            var validationResult = _chargingHistoryValidator.Validate(chargingHistory);

            if (!validationResult.IsValid)
            {
                throw new InvalidException(
                    string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))
                );
            }
        }
    }
}
