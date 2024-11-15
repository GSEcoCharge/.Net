using EcoCharge.domain.model;

namespace EcoCharge.domain.useCase.dtos;

public interface IChargingHistoryUseCase
{
    ChargingHistory FindById(int id);
    void Create(ChargingHistory chargingHistory);
    ChargingHistory Update(int id, ChargingHistory chargingHistory);
    void Delete(int id);
}