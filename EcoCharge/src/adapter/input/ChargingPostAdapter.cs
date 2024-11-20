using FluentValidation;
using EcoCharge.domain.model;
using EcoCharge.domain.useCase.dto;
using EcoCharge.adapter.input.dtos;
using EcoCharge.domain.useCase.dtos;
using EcoCharge.infra.exception;

namespace EcoCharge.adapter.input
{
    public class ChargingPostAdapter : IChargingPostAdapter
    {
        private readonly IChargingPostUseCase _chargingPostUseCase;
        private readonly IValidator<ChargingPost> _chargingPostValidator;

        public ChargingPostAdapter(IChargingPostUseCase chargingPostUseCase, IValidator<ChargingPost> chargingPostValidator)
        {
            _chargingPostUseCase = chargingPostUseCase;
            _chargingPostValidator = chargingPostValidator;
        }

        public ChargingPost FindById(string id)
        {
            var chargingPost = _chargingPostUseCase.FindById(id);
    
            if (chargingPost == null)
            {
                throw new NotFoundException($"ChargingPost with ID {id} not found.");
            }

            return chargingPost;
        }

        public void Create(ChargingPost chargingPost)
        {
            ValidateChargingPost(chargingPost);
            _chargingPostUseCase.Create(chargingPost);
        }

        public ChargingPost Update(string id, ChargingPost chargingPost)
        {
            ValidateChargingPost(chargingPost);
            return _chargingPostUseCase.Update(id, chargingPost);
        }

        public void Delete(string id)
        {
            _chargingPostUseCase.Delete(id);
        }

        private void ValidateChargingPost(ChargingPost chargingPost)
        {
            var validationResult = _chargingPostValidator.Validate(chargingPost);

            if (!validationResult.IsValid)
            {
                throw new InvalidException(
                    string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))
                );
            }
        }
    }
}
