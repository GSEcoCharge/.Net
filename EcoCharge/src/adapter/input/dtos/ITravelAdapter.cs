using EcoCharge.domain.model;

namespace EcoCharge.adapter.input.dtos;

public interface ITravelAdapter
{
    Travel FindById(string id);
    void Create(Travel travel);
    Travel Update(string id, Travel travel);
    void Delete(string id);
}