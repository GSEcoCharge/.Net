using EcoCharge.domain.model;

namespace EcoCharge.domain.repository;

public interface IEvaluationRepository
{
    Evaluation FindById(string id);
    void Create(Evaluation evaluation);
    Evaluation Update(string id, Evaluation evaluation);
    void Delete(string id);
}