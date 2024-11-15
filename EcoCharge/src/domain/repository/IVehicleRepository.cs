using EcoCharge.domain.model;

namespace EcoCharge.domain.repository;

public interface IVehicleRepository
{
    Vehicle FindById(int id);
    void Create(Vehicle vehicle);
    Vehicle Update(int id, Vehicle vehicle);
    void Delete(int id);
}