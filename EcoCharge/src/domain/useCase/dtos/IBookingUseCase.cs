using EcoCharge.domain.model;

namespace EcoCharge.domain.useCase.dtos;

public interface IBookingUseCase
{
    Booking FindById(string id);
    void Create(Booking booking);
    Booking Update(string id, Booking booking);
    void Delete(string id);
}