using EcoCharge.domain.model;

namespace EcoCharge.domain.repository;

public interface IChargingPointRepository
{
    ChargingPoint FindById(string id);
    void Create(ChargingPoint chargingPoint);
    ChargingPoint Update(string id, ChargingPoint chargingPoint);
    void Delete(string id);
}