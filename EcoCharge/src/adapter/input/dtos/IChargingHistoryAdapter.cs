using EcoCharge.domain.model;

namespace EcoCharge.adapter.input.dtos;

public interface IChargingHistoryAdapter
{
    ChargingHistory FindById(string id);
    void Create(ChargingHistory chargingHistory);
    ChargingHistory Update(string id, ChargingHistory chargingHistory);
    void Delete(string id);
}