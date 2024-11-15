using EcoCharge.domain.model;

namespace EcoCharge.domain.useCase.dtos;

public interface IBookingUseCase
{
    Booking FindById(int id);
    void Create(Booking booking);
    Booking Update(int id, Booking booking);
    void Delete(int id);
}