using EcoCharge.domain.model;

namespace EcoCharge.domain.useCase.dtos;

public interface IUserUseCase
{
    User FindById(int id);
    void Create(User user);
    User Update(int id, User user);
    void Delete(int id);
}