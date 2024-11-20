using EcoCharge.domain.model;

namespace EcoCharge.domain.repository;

public interface IStopingPointRepository
{
    StopingPoint FindById(string id);
    void Create(StopingPoint stopingPoint);
    StopingPoint Update(string id, StopingPoint stopingPoint);
    void Delete(string id);
}