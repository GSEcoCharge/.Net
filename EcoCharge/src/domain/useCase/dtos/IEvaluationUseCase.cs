using EcoCharge.domain.model;

namespace EcoCharge.domain.useCase.dtos;

public interface IEvaluationUseCase
{
    Evaluation FindById(int id);
    void Create(Evaluation evaluation);
    Evaluation Update(int id, Evaluation evaluation);
    void Delete(int id);
}