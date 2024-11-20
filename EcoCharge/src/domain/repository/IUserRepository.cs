using EcoCharge.domain.model;

namespace EcoCharge.domain.repository;

public interface IUserRepository
{
    User FindById(string id);
    void Create(User user);
    User Update(string id, User user);
    void Delete(string id);
}