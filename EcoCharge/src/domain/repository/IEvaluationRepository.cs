using EcoCharge.domain.model;

namespace EcoCharge.domain.repository;

public interface IEvaluationRepository
{
    Evaluation FindById(int id);
    void Create(Evaluation evaluation);
    Evaluation Update(int id, Evaluation evaluation);
    void Delete(int id);
}