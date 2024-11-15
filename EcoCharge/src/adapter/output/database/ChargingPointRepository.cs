using EcoCharge.domain.model;
using EcoCharge.domain.repository;

namespace EcoCharge.adapter.output.database
{
    public class ChargingPointRepository : IChargingPointRepository
    {
        private readonly ApplicationDbContext _context;

        public ChargingPointRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ChargingPoint FindById(int id)
        {
            var chargingPoint = _context.ChargingPoints.FirstOrDefault(c => c.Id == id);

            if (chargingPoint == null)
            {
                throw new KeyNotFoundException($"ChargingPoint with ID {id} not found.");
            }

            return chargingPoint;
        }

        public void Create(ChargingPoint chargingPoint)
        {
            _context.ChargingPoints.Add(chargingPoint);
            _context.SaveChanges();
        }

        public ChargingPoint Update(int id, ChargingPoint chargingPoint)
        {
            var existingChargingPoint = _context.ChargingPoints.FirstOrDefault(c => c.Id == id);

            if (existingChargingPoint == null)
            {
                throw new KeyNotFoundException($"ChargingPoint with ID {id} not found.");
            }

            existingChargingPoint.ChargingStationId = chargingPoint.ChargingStationId;
            existingChargingPoint.ConnectorType = chargingPoint.ConnectorType;
            existingChargingPoint.ChargingSpeed = chargingPoint.ChargingSpeed;
            existingChargingPoint.Availability = chargingPoint.Availability;
            existingChargingPoint.Reservable = chargingPoint.Reservable;

            _context.ChargingPoints.Update(existingChargingPoint);
            _context.SaveChanges();

            return existingChargingPoint;
        }
        
        public void Delete(int id)
        {
            var chargingPoint = _context.ChargingPoints.FirstOrDefault(c => c.Id == id);

            if (chargingPoint != null)
            {
                _context.ChargingPoints.Remove(chargingPoint);
                _context.SaveChanges();
            }
        }
    }
}