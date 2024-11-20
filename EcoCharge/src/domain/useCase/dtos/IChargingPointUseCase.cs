using EcoCharge.domain.model;

namespace EcoCharge.domain.useCase.dtos;

public interface IChargingPointUseCase
{
    ChargingPoint FindById(string id);
    void Create(ChargingPoint chargingPoint);
    ChargingPoint Update(string id, ChargingPoint chargingPoint);
    void Delete(string id);
}