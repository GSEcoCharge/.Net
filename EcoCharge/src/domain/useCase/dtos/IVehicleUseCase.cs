using EcoCharge.domain.model;

namespace EcoCharge.domain.useCase.dto;

public interface IVehicleUseCase
{
    Vehicle FindById(string id);
    void Create(Vehicle vehicle);
    Vehicle Update(string id, Vehicle vehicle);
    void Delete(string id);
}