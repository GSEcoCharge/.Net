using EcoCharge.domain.model;

namespace EcoCharge.domain.repository;

public interface IChargingPostRepository
{
    ChargingPost FindById(string id);
    void Create(ChargingPost chargingPost);
    ChargingPost Update(string id, ChargingPost chargingPost);
    void Delete(string id);
}