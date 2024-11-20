using EcoCharge.domain.model;

namespace EcoCharge.domain.repository;

public interface IVehicleRepository
{
    Vehicle FindById(string id);
    void Create(Vehicle vehicle);
    Vehicle Update(string id, Vehicle vehicle);
    void Delete(string id);
}