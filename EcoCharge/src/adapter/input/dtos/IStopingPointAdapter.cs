using EcoCharge.domain.model;

namespace EcoCharge.adapter.input.dtos;

public interface IStopingPointAdapter
{
    StopingPoint FindById(int id);
    void Create(StopingPoint stopingPoint);
    StopingPoint Update(int id, StopingPoint stopingPoint);
    void Delete(int id);
}