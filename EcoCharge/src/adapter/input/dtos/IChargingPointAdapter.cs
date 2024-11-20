using EcoCharge.domain.model;

namespace EcoCharge.adapter.input.dtos;

public interface IChargingPointAdapter
{
    ChargingPoint FindById(string id);
    void Create(ChargingPoint chargingPoint);
    ChargingPoint Update(string id, ChargingPoint chargingPoint);
    void Delete(string id);
}