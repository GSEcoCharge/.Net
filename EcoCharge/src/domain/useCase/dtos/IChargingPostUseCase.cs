using EcoCharge.domain.model;

namespace EcoCharge.domain.useCase.dtos;

public interface IChargingPostUseCase
{
    ChargingPost FindById(int id);
    void Create(ChargingPost chargingPost);
    ChargingPost Update(int id, ChargingPost chargingPost);
    void Delete(int id);
}