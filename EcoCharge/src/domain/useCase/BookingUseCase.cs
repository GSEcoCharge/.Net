using EcoCharge.domain.model;
using EcoCharge.domain.repository;
using EcoCharge.domain.useCase.dto;
using EcoCharge.domain.useCase.dtos;
using EcoCharge.infra.exception;

namespace EcoCharge.domain.useCase
{
    public class BookingUseCase : IBookingUseCase
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingUseCase(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public Booking FindById(string id)
        {
            var booking = _bookingRepository.FindById(id);

            if (booking == null)
            {
                throw new NotFoundException($"Booking with ID {id} not found.");
            }

            return booking;
        }

        public void Create(Booking booking)
        {
            var persistedBooking = _bookingRepository.FindById(booking.Id);

            if (persistedBooking != null)
            {
                throw new AlreadyExistsException($"Booking with ID {booking.Id} already exists.");
            }

            _bookingRepository.Create(booking);
        }

        public Booking Update(string id, Booking booking)
        {
            var persistedBooking = _bookingRepository.FindById(id);

            if (persistedBooking == null)
            {
                throw new NotFoundException($"Booking with ID {id} not found.");
            }

            _bookingRepository.Update(id, booking);

            return booking;
        }

        public void Delete(string id)
        {
            var persistedBooking = _bookingRepository.FindById(id);

            if (persistedBooking == null)
            {
                throw new NotFoundException($"Booking with ID {id} not found.");
            }

            _bookingRepository.Delete(id);
        }
    }
}