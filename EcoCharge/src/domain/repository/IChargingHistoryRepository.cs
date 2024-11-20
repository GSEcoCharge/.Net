using EcoCharge.domain.model;

namespace EcoCharge.domain.repository;

public interface IChargingHistoryRepository
{
    ChargingHistory FindById(string id);
    void Create(ChargingHistory chargingHistory);
    ChargingHistory Update(string id, ChargingHistory chargingHistory);
    void Delete(string id);
}