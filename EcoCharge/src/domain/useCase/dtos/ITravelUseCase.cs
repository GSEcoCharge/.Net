using EcoCharge.domain.model;

namespace EcoCharge.domain.useCase.dtos;

public interface ITravelUseCase
{
    Travel FindById(string id);
    void Create(Travel travel);
    Travel Update(string id, Travel travel);
    void Delete(string id);
}