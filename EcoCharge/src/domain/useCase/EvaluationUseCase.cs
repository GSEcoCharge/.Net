using EcoCharge.domain.model;
using EcoCharge.domain.repository;
using EcoCharge.domain.useCase.dto;
using EcoCharge.domain.useCase.dtos;
using EcoCharge.infra.exception;

namespace EcoCharge.domain.useCase
{
    public class EvaluationUseCase : IEvaluationUseCase
    {
        private readonly IEvaluationRepository _evaluationRepository;

        public EvaluationUseCase(IEvaluationRepository evaluationRepository)
        {
            _evaluationRepository = evaluationRepository;
        }

        public Evaluation FindById(int id)
        {
            var evaluation = _evaluationRepository.FindById(id);

            if (evaluation == null)
            {
                throw new NotFoundException($"Evaluation with ID {id} not found.");
            }

            return evaluation;
        }

        public void Create(Evaluation evaluation)
        {
            var persistedEvaluation = _evaluationRepository.FindById(evaluation.Id);

            if (persistedEvaluation != null)
            {
                throw new AlreadyExistsException($"Evaluation with ID {evaluation.Id} already exists.");
            }

            _evaluationRepository.Create(evaluation);
        }

        public Evaluation Update(int id, Evaluation evaluation)
        {
            var persistedEvaluation = _evaluationRepository.FindById(id);

            if (persistedEvaluation == null)
            {
                throw new NotFoundException($"Evaluation with ID {id} not found.");
            }

            _evaluationRepository.Update(id, evaluation);

            return evaluation;
        }

        public void Delete(int id)
        {
            var persistedEvaluation = _evaluationRepository.FindById(id);

            if (persistedEvaluation == null)
            {
                throw new NotFoundException($"Evaluation with ID {id} not found.");
            }

            _evaluationRepository.Delete(id);
        }
    }
}