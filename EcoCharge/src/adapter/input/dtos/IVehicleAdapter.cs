using EcoCharge.domain.model;

namespace EcoCharge.adapter.input.dtos;

public interface IVehicleAdapter
{
    Vehicle FindById(int id);
    void Create(Vehicle vehicle);
    Vehicle Update(int id, Vehicle vehicle);
    void Delete(int id);
}