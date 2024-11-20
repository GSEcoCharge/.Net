using FluentValidation;
using EcoCharge.domain.model;
using EcoCharge.domain.useCase.dto;
using EcoCharge.adapter.input.dtos;
using EcoCharge.domain.useCase.dtos;
using EcoCharge.infra.exception;

namespace EcoCharge.adapter.input
{
    public class EvaluationAdapter : IEvaluationAdapter
    {
        private readonly IEvaluationUseCase _evaluationUseCase;
        private readonly IValidator<Evaluation> _evaluationValidator;

        public EvaluationAdapter(IEvaluationUseCase evaluationUseCase, IValidator<Evaluation> evaluationValidator)
        {
            _evaluationUseCase = evaluationUseCase;
            _evaluationValidator = evaluationValidator;
        }

        public Evaluation FindById(string id)
        {
            var evaluation = _evaluationUseCase.FindById(id);
    
            if (evaluation == null)
            {
                throw new NotFoundException($"Evaluation with ID {id} not found.");
            }

            return evaluation;
        }

        public void Create(Evaluation evaluation)
        {
            ValidateEvaluation(evaluation);
            _evaluationUseCase.Create(evaluation);
        }

        public Evaluation Update(string id, Evaluation evaluation)
        {
            ValidateEvaluation(evaluation);
            return _evaluationUseCase.Update(id, evaluation);
        }

        public void Delete(string id)
        {
            _evaluationUseCase.Delete(id);
        }

        private void ValidateEvaluation(Evaluation evaluation)
        {
            var validationResult = _evaluationValidator.Validate(evaluation);

            if (!validationResult.IsValid)
            {
                throw new InvalidException(
                    string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))
                );
            }
        }
    }
}
