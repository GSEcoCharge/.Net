using EcoCharge.domain.model;

namespace EcoCharge.domain.useCase.dtos;

public interface IChargingPostUseCase
{
    ChargingPost FindById(string id);
    void Create(ChargingPost chargingPost);
    ChargingPost Update(string id, ChargingPost chargingPost);
    void Delete(string id);
}