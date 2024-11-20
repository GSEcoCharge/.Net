using EcoCharge.domain.model;

namespace EcoCharge.domain.repository;

public interface IBookingRepository
{
    Booking FindById(string id);
    void Create(Booking booking);
    Booking Update(string id, Booking booking);
    void Delete(string id);
}