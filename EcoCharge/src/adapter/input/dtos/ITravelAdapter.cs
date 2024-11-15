using EcoCharge.domain.model;

namespace EcoCharge.adapter.input.dtos;

public interface ITravelAdapter
{
    Travel FindById(int id);
    void Create(Travel travel);
    Travel Update(int id, Travel travel);
    void Delete(int id);
}