using EcoCharge.domain.model;

namespace EcoCharge.domain.useCase.dtos;

public interface IStopingPointUseCase
{
    StopingPoint FindById(string id);
    void Create(StopingPoint stopingPoint);
    StopingPoint Update(string id, StopingPoint stopingPoint);
    void Delete(string id);
}