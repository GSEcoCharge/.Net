using EcoCharge.domain.model;

namespace EcoCharge.domain.repository;

public interface ITravelRepository
{
    Travel FindById(int id);
    void Create(Travel travel);
    Travel Update(int id, Travel travel);
    void Delete(int id);
}