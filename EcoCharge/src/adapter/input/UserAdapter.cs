using FluentValidation;
using EcoCharge.domain.model;
using EcoCharge.domain.useCase.dto;
using EcoCharge.adapter.input.dtos;
using EcoCharge.domain.useCase.dtos;
using EcoCharge.infra.exception;

namespace EcoCharge.adapter.input
{
    public class UserAdapter : IUserAdapter
    {
        private readonly IUserUseCase _userUseCase;
        private readonly IValidator<User> _userValidator;

        public UserAdapter(IUserUseCase userUseCase, IValidator<User> userValidator)
        {
            _userUseCase = userUseCase;
            _userValidator = userValidator;
        }

        public User FindById(string id)
        {
            var user = _userUseCase.FindById(id);
    
            if (user == null)
            {
                throw new NotFoundException($"User with ID {id} not found.");
            }

            return user;
        }

        public void Create(User user)
        {
            ValidateUser(user);
            _userUseCase.Create(user);
        }

        public User Update(string id, User user)
        {
            ValidateUser(user);
            return _userUseCase.Update(id, user);
        }

        public void Delete(string id)
        {
            _userUseCase.Delete(id);
        }

        private void ValidateUser(User user)
        {
            var validationResult = _userValidator.Validate(user);

            if (!validationResult.IsValid)
            {
                throw new InvalidException(
                    string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))
                );
            }
        }
    }
}
