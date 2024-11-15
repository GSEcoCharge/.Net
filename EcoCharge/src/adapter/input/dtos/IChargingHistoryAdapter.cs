using EcoCharge.domain.model;

namespace EcoCharge.adapter.input.dtos;

public interface IChargingHistoryAdapter
{
    ChargingHistory FindById(int id);
    void Create(ChargingHistory chargingHistory);
    ChargingHistory Update(int id, ChargingHistory chargingHistory);
    void Delete(int id);
}