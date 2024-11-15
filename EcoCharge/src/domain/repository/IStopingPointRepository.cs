using EcoCharge.domain.model;

namespace EcoCharge.domain.repository;

public interface IStopingPointRepository
{
    StopingPoint FindById(int id);
    void Create(StopingPoint stopingPoint);
    StopingPoint Update(int id, StopingPoint stopingPoint);
    void Delete(int id);
}