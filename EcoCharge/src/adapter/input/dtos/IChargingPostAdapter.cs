using EcoCharge.domain.model;

namespace EcoCharge.adapter.input.dtos;

public interface IChargingPostAdapter
{
    ChargingPost FindById(string id);
    void Create(ChargingPost chargingPost);
    ChargingPost Update(string id, ChargingPost chargingPost);
    void Delete(string id);
}