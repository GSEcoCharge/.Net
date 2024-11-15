using EcoCharge.domain.model;
using EcoCharge.domain.repository;

namespace EcoCharge.adapter.output.database
{
    public class ChargingHistoryRepository : IChargingHistoryRepository
    {
        private readonly ApplicationDbContext _context;

        public ChargingHistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ChargingHistory FindById(int id)
        {
            var chargingHistory = _context.ChargingHistories.FirstOrDefault(c => c.Id == id);

            if (chargingHistory == null)
            {
                throw new KeyNotFoundException($"ChargingHistory with ID {id} not found.");
            }

            return chargingHistory;
        }

        public void Create(ChargingHistory chargingHistory)
        {
            _context.ChargingHistories.Add(chargingHistory);
            _context.SaveChanges();
        }

        public ChargingHistory Update(int id, ChargingHistory chargingHistory)
        {
            var existingChargingHistory = _context.ChargingHistories.FirstOrDefault(c => c.Id == id);

            if (existingChargingHistory == null)
            {
                throw new KeyNotFoundException($"ChargingHistory with ID {id} not found.");
            }

            existingChargingHistory.UserId = chargingHistory.UserId;
            existingChargingHistory.ChargingPointId = chargingHistory.ChargingPointId;
            existingChargingHistory.Date = chargingHistory.Date;
            existingChargingHistory.ConsumedEnergy = chargingHistory.ConsumedEnergy;
            existingChargingHistory.AvoidedEmissions = chargingHistory.AvoidedEmissions;

            _context.ChargingHistories.Update(existingChargingHistory);
            _context.SaveChanges();

            return existingChargingHistory;
        }
        
        public void Delete(int id)
        {
            var chargingHistory = _context.ChargingHistories.FirstOrDefault(c => c.Id == id);

            if (chargingHistory != null)
            {
                _context.ChargingHistories.Remove(chargingHistory);
                _context.SaveChanges();
            }
        }
    }
}