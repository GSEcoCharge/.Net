using EcoCharge.domain.model;

namespace EcoCharge.adapter.input.dtos;

public interface IEvaluationAdapter
{
    Evaluation FindById(int id);
    void Create(Evaluation evaluation);
    Evaluation Update(int id, Evaluation evaluation);
    void Delete(int id);
}