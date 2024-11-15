using EcoCharge.domain.model;

namespace EcoCharge.adapter.input.dtos;

public interface IBookingAdapter
{
    Booking FindById(int id);
    void Create(Booking booking);
    Booking Update(int id, Booking booking);
    void Delete(int id);
}