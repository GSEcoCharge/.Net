using EcoCharge.domain.model;

namespace EcoCharge.adapter.input.dtos;

public interface IVehicleAdapter
{
    Vehicle FindById(string id);
    void Create(Vehicle vehicle);
    Vehicle Update(string id, Vehicle vehicle);
    void Delete(string id);
}