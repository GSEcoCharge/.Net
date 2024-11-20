using EcoCharge.domain.model;

namespace EcoCharge.adapter.input.dtos;

public interface IUserAdapter
{
    User FindById(string id);
    void Create(User user);
    User Update(string id, User user);
    void Delete(string id);
}