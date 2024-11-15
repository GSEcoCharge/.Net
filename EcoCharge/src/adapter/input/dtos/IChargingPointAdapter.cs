using EcoCharge.domain.model;

namespace EcoCharge.adapter.input.dtos;

public interface IChargingPointAdapter
{
    ChargingPoint FindById(int id);
    void Create(ChargingPoint chargingPoint);
    ChargingPoint Update(int id, ChargingPoint chargingPoint);
    void Delete(int id);
}