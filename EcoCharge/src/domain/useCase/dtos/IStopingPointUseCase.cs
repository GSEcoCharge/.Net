using EcoCharge.domain.model;

namespace EcoCharge.domain.useCase.dtos;

public interface IStopingPointUseCase
{
    StopingPoint FindById(int id);
    void Create(StopingPoint stopingPoint);
    StopingPoint Update(int id, StopingPoint stopingPoint);
    void Delete(int id);
}