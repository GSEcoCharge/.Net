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

        public ChargingHistory FindById(string id)
        {
            return _context.ChargingHistories.FirstOrDefault(c => c.Id == id);
        }

        public void Create(ChargingHistory chargingHistory)
        {
            _context.ChargingHistories.Add(chargingHistory);
            _context.SaveChanges();
        }

        public ChargingHistory Update(string id, ChargingHistory chargingHistory)
        {
            var existingChargingHistory = _context.ChargingHistories.FirstOrDefault(c => c.Id == id);

            if (existingChargingHistory == null)
            {
                throw new KeyNotFoundException($"ChargingHistory with ID {id} not found.");
            }

            existingChargingHistory.UserId = chargingHistory.UserId;
            existingChargingHistory.ChargingPointId = chargingHistory.ChargingPointId;
            existingChargingHistory.ChargingHistoryDate = chargingHistory.ChargingHistoryDate;
            existingChargingHistory.ConsumedEnergy = chargingHistory.ConsumedEnergy;
            existingChargingHistory.AvoidedEmissions = chargingHistory.AvoidedEmissions;

            _context.ChargingHistories.Update(existingChargingHistory);
            _context.SaveChanges();

            return existingChargingHistory;
        }
        
        public void Delete(string id)
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