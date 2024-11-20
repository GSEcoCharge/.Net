using EcoCharge.domain.model;

namespace EcoCharge.domain.repository;

public interface ITravelRepository
{
    Travel FindById(string id);
    void Create(Travel travel);
    Travel Update(string id, Travel travel);
    void Delete(string id);
}