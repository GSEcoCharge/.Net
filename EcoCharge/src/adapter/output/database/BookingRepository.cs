using EcoCharge.domain.model;
using EcoCharge.domain.repository;

namespace EcoCharge.adapter.output.database
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Booking FindById(string id)
        {
            return _context.Bookings.FirstOrDefault(c => c.Id == id);
        }

        public void Create(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        public Booking Update(string id, Booking booking)
        {
            var existingBooking = _context.Bookings.FirstOrDefault(c => c.Id == id);

            if (existingBooking == null)
            {
                throw new KeyNotFoundException($"Booking with ID {id} not found.");
            }

            existingBooking.UserId = booking.UserId;
            existingBooking.ChargingPointId = booking.ChargingPointId;
            existingBooking.BookingDate = booking.BookingDate;
            existingBooking.Status = booking.Status;

            _context.Bookings.Update(existingBooking);
            _context.SaveChanges();

            return existingBooking;
        }
        
        public void Delete(string id)
        {
            var booking = _context.Bookings.FirstOrDefault(c => c.Id == id);

            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
            }
        }
    }
}