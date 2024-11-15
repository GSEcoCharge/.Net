using FluentValidation;
using EcoCharge.domain.model;
using EcoCharge.domain.useCase.dto;
using EcoCharge.adapter.input.dtos;
using EcoCharge.domain.useCase.dtos;
using EcoCharge.infra.exception;

namespace EcoCharge.adapter.input
{
    public class BookingAdapter : IBookingAdapter
    {
        private readonly IBookingUseCase _bookingUseCase;
        private readonly IValidator<Booking> _bookingValidator;

        public BookingAdapter(IBookingUseCase bookingUseCase, IValidator<Booking> bookingValidator)
        {
            _bookingUseCase = bookingUseCase;
            _bookingValidator = bookingValidator;
        }

        public Booking FindById(int id)
        {
            var booking = _bookingUseCase.FindById(id);
    
            if (booking == null)
            {
                throw new NotFoundException($"Booking with ID {id} not found.");
            }

            return booking;
        }

        public void Create(Booking booking)
        {
            ValidateBooking(booking);
            _bookingUseCase.Create(booking);
        }

        public Booking Update(int id, Booking booking)
        {
            ValidateBooking(booking);
            return _bookingUseCase.Update(id, booking);
        }

        public void Delete(int id)
        {
            _bookingUseCase.Delete(id);
        }

        private void ValidateBooking(Booking booking)
        {
            var validationResult = _bookingValidator.Validate(booking);

            if (!validationResult.IsValid)
            {
                throw new InvalidException(
                    string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))
                );
            }
        }
    }
}
