using EcoCharge.domain.model;

namespace EcoCharge.domain.repository;

public interface IChargingPostRepository
{
    ChargingPost FindById(int id);
    void Create(ChargingPost chargingPost);
    ChargingPost Update(int id, ChargingPost chargingPost);
    void Delete(int id);
}