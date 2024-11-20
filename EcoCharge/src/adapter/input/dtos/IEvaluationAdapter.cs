using EcoCharge.domain.model;

namespace EcoCharge.adapter.input.dtos;

public interface IEvaluationAdapter
{
    Evaluation FindById(string id);
    void Create(Evaluation evaluation);
    Evaluation Update(string id, Evaluation evaluation);
    void Delete(string id);
}