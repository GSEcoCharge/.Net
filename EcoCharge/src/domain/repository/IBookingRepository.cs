using EcoCharge.domain.model;

namespace EcoCharge.domain.repository;

public interface IBookingRepository
{
    Booking FindById(int id);
    void Create(Booking booking);
    Booking Update(int id, Booking booking);
    void Delete(int id);
}