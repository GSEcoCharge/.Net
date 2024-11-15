using EcoCharge.domain.model;

namespace EcoCharge.domain.useCase.dto;

public interface IVehicleUseCase
{
    Vehicle FindById(int id);
    void Create(Vehicle vehicle);
    Vehicle Update(int id, Vehicle vehicle);
    void Delete(int id);
}