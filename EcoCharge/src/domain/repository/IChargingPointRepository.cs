using EcoCharge.domain.model;

namespace EcoCharge.domain.repository;

public interface IChargingPointRepository
{
    ChargingPoint FindById(int id);
    void Create(ChargingPoint chargingPoint);
    ChargingPoint Update(int id, ChargingPoint chargingPoint);
    void Delete(int id);
}