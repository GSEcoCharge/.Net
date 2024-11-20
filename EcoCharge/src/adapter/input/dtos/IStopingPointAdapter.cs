using EcoCharge.domain.model;

namespace EcoCharge.adapter.input.dtos;

public interface IStopingPointAdapter
{
    StopingPoint FindById(string id);
    void Create(StopingPoint stopingPoint);
    StopingPoint Update(string id, StopingPoint stopingPoint);
    void Delete(string id);
}