using EcoCharge.domain.model;

namespace EcoCharge.domain.repository;

public interface IUserRepository
{
    User FindById(int id);
    void Create(User user);
    User Update(int id, User user);
    void Delete(int id);
}