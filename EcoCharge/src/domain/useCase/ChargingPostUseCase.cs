using EcoCharge.domain.model;
using EcoCharge.domain.repository;
using EcoCharge.domain.useCase.dto;
using EcoCharge.domain.useCase.dtos;
using EcoCharge.infra.exception;

namespace EcoCharge.domain.useCase
{
    public class ChargingPostUseCase : IChargingPostUseCase
    {
        private readonly IChargingPostRepository _chargingPostRepository;

        public ChargingPostUseCase(IChargingPostRepository chargingPostRepository)
        {
            _chargingPostRepository = chargingPostRepository;
        }

        public ChargingPost FindById(string id)
        {
            var chargingPost = _chargingPostRepository.FindById(id);

            if (chargingPost == null)
            {
                throw new NotFoundException($"ChargingPost with ID {id} not found.");
            }

            return chargingPost;
        }

        public void Create(ChargingPost chargingPost)
        {
            var persistedChargingPost = _chargingPostRepository.FindById(chargingPost.Id);

            if (persistedChargingPost != null)
            {
                throw new AlreadyExistsException($"ChargingPost with ID {chargingPost.Id} already exists.");
            }

            _chargingPostRepository.Create(chargingPost);
        }

        public ChargingPost Update(string id, ChargingPost chargingPost)
        {
            var persistedChargingPost = _chargingPostRepository.FindById(id);

            if (persistedChargingPost == null)
            {
                throw new NotFoundException($"ChargingPost with ID {id} not found.");
            }

            _chargingPostRepository.Update(id, chargingPost);

            return chargingPost;
        }

        public void Delete(string id)
        {
            var persistedChargingPost = _chargingPostRepository.FindById(id);

            if (persistedChargingPost == null)
            {
                throw new NotFoundException($"ChargingPost with ID {id} not found.");
            }

            _chargingPostRepository.Delete(id);
        }
    }
}