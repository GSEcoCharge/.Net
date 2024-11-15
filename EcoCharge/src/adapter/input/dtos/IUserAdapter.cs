using EcoCharge.domain.model;

namespace EcoCharge.adapter.input.dtos;

public interface IUserAdapter
{
    User FindById(int id);
    void Create(User user);
    User Update(int id, User user);
    void Delete(int id);
}