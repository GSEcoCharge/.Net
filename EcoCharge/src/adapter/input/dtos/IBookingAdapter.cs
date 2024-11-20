using EcoCharge.domain.model;

namespace EcoCharge.adapter.input.dtos;

public interface IBookingAdapter
{
    Booking FindById(string id);
    void Create(Booking booking);
    Booking Update(string id, Booking booking);
    void Delete(string id);
}