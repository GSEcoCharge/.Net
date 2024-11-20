using EcoCharge.domain.model;

namespace EcoCharge.domain.useCase.dtos;

public interface IEvaluationUseCase
{
    Evaluation FindById(string id);
    void Create(Evaluation evaluation);
    Evaluation Update(string id, Evaluation evaluation);
    void Delete(string id);
}