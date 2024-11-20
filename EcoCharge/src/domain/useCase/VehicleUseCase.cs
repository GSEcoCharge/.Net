using EcoCharge.domain.model;
using EcoCharge.domain.repository;
using EcoCharge.domain.useCase.dto;
using EcoCharge.infra.exception;

namespace EcoCharge.domain.useCase
{
    public class VehicleUseCase : IVehicleUseCase
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleUseCase(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public Vehicle FindById(string id)
        {
            var vehicle = _vehicleRepository.FindById(id);

            if (vehicle == null)
            {
                throw new NotFoundException($"Vehicle with ID {id} not found.");
            }

            return vehicle;
        }

        public void Create(Vehicle vehicle)
        {
            var persistedVehicle = _vehicleRepository.FindById(vehicle.Id);

            if (persistedVehicle != null)
            {
                throw new AlreadyExistsException($"Vehicle with ID {vehicle.Id} already exists.");
            }

            _vehicleRepository.Create(vehicle);
        }

        public Vehicle Update(string id, Vehicle vehicle)
        {
            var persistedVehicle = _vehicleRepository.FindById(id);

            if (persistedVehicle == null)
            {
                throw new NotFoundException($"Vehicle with ID {id} not found.");
            }

            _vehicleRepository.Update(id, vehicle);

            return vehicle;
        }

        public void Delete(string id)
        {
            var persistedVehicle = _vehicleRepository.FindById(id);

            if (persistedVehicle == null)
            {
                throw new NotFoundException($"Vehicle with ID {id} not found.");
            }

            _vehicleRepository.Delete(id);
        }
    }
}