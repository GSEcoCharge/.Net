using EcoCharge.domain.model;

namespace EcoCharge.domain.useCase.dtos;

public interface IUserUseCase
{
    User FindById(string id);
    void Create(User user);
    User Update(string id, User user);
    void Delete(string id);
}