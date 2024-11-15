using FluentValidation;
using EcoCharge.domain.model;
using EcoCharge.domain.useCase.dto;
using EcoCharge.adapter.input.dtos;
using EcoCharge.infra.exception;

namespace EcoCharge.adapter.input
{
    public class VehicleAdapter : IVehicleAdapter
    {
        private readonly IVehicleUseCase _vehicleUseCase;
        private readonly IValidator<Vehicle> _vehicleValidator;

        public VehicleAdapter(IVehicleUseCase vehicleUseCase, IValidator<Vehicle> vehicleValidator)
        {
            _vehicleUseCase = vehicleUseCase;
            _vehicleValidator = vehicleValidator;
        }

        public Vehicle FindById(int id)
        {
            var vehicle = _vehicleUseCase.FindById(id);
    
            if (vehicle == null)
            {
                throw new NotFoundException($"Vehicle with ID {id} not found.");
            }

            return vehicle;
        }

        public void Create(Vehicle vehicle)
        {
            ValidateVehicle(vehicle);
            _vehicleUseCase.Create(vehicle);
        }

        public Vehicle Update(int id, Vehicle vehicle)
        {
            ValidateVehicle(vehicle);
            return _vehicleUseCase.Update(id, vehicle);
        }

        public void Delete(int id)
        {
            _vehicleUseCase.Delete(id);
        }

        private void ValidateVehicle(Vehicle vehicle)
        {
            var validationResult = _vehicleValidator.Validate(vehicle);

            if (!validationResult.IsValid)
            {
                throw new InvalidException(
                    string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))
                );
            }
        }
    }
}
