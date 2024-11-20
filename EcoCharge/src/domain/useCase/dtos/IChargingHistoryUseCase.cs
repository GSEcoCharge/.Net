using EcoCharge.domain.model;

namespace EcoCharge.domain.useCase.dtos;

public interface IChargingHistoryUseCase
{
    ChargingHistory FindById(string id);
    void Create(ChargingHistory chargingHistory);
    ChargingHistory Update(string id, ChargingHistory chargingHistory);
    void Delete(string id);
}