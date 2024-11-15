using EcoCharge.domain.model;

namespace EcoCharge.domain.useCase.dtos;

public interface IChargingPointUseCase
{
    ChargingPoint FindById(int id);
    void Create(ChargingPoint chargingPoint);
    ChargingPoint Update(int id, ChargingPoint chargingPoint);
    void Delete(int id);
}