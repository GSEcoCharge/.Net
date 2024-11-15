using EcoCharge.domain.model;

namespace EcoCharge.domain.repository;

public interface IChargingHistoryRepository
{
    ChargingHistory FindById(int id);
    void Create(ChargingHistory chargingHistory);
    ChargingHistory Update(int id, ChargingHistory chargingHistory);
    void Delete(int id);
}