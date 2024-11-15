using EcoCharge.domain.model;

namespace EcoCharge.adapter.input.dtos;

public interface IChargingPostAdapter
{
    ChargingPost FindById(int id);
    void Create(ChargingPost chargingPost);
    ChargingPost Update(int id, ChargingPost chargingPost);
    void Delete(int id);
}