using EcoCharge.domain.model;
using EcoCharge.domain.repository;

namespace EcoCharge.adapter.output.database
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationDbContext _context;

        public VehicleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Vehicle FindById(string id)
        {
            return _context.Vehicles.FirstOrDefault(c => c.Id == id);
        }

        public void Create(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
        }

        public Vehicle Update(string id, Vehicle vehicle)
        {
            var existingVehicle = _context.Vehicles.FirstOrDefault(c => c.Id == id);

            if (existingVehicle == null)
            {
                throw new KeyNotFoundException($"Vehicle with ID {id} not found.");
            }

            existingVehicle.UserId = vehicle.UserId;
            existingVehicle.Brand = vehicle.Brand;
            existingVehicle.Model = vehicle.Model;
            existingVehicle.VehicleYear = vehicle.VehicleYear;
            existingVehicle.Autonomy = vehicle.Autonomy;
            existingVehicle.ConnectorType = vehicle.ConnectorType;

            _context.Vehicles.Update(existingVehicle);
            _context.SaveChanges();

            return existingVehicle;
        }
        
        public void Delete(string id)
        {
            var vehicle = _context.Vehicles.FirstOrDefault(c => c.Id == id);

            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
                _context.SaveChanges();
            }
        }
    }
}