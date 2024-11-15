using EcoCharge.domain.model;
using EcoCharge.domain.repository;
using EcoCharge.domain.useCase.dto;
using EcoCharge.domain.useCase.dtos;
using EcoCharge.infra.exception;

namespace EcoCharge.domain.useCase
{
    public class UserUseCase : IUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public UserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User FindById(int id)
        {
            var user = _userRepository.FindById(id);

            if (user == null)
            {
                throw new NotFoundException($"User with ID {id} not found.");
            }

            return user;
        }

        public void Create(User user)
        {
            var persistedUser = _userRepository.FindById(user.Id);

            if (persistedUser != null)
            {
                throw new AlreadyExistsException($"User with ID {user.Id} already exists.");
            }

            _userRepository.Create(user);
        }

        public User Update(int id, User user)
        {
            var persistedUser = _userRepository.FindById(id);

            if (persistedUser == null)
            {
                throw new NotFoundException($"User with ID {id} not found.");
            }

            _userRepository.Update(id, user);

            return user;
        }

        public void Delete(int id)
        {
            var persistedUser = _userRepository.FindById(id);

            if (persistedUser == null)
            {
                throw new NotFoundException($"User with ID {id} not found.");
            }

            _userRepository.Delete(id);
        }
    }
}