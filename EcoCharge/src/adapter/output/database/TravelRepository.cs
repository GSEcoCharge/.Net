using EcoCharge.domain.model;
using EcoCharge.domain.repository;

namespace EcoCharge.adapter.output.database
{
    public class TravelRepository : ITravelRepository
    {
        private readonly ApplicationDbContext _context;

        public TravelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Travel FindById(int id)
        {
            var user = _context.Travels.FirstOrDefault(c => c.Id == id);

            if (user == null)
            {
                throw new KeyNotFoundException($"Travel with ID {id} not found.");
            }

            return user;
        }

        public void Create(Travel user)
        {
            _context.Travels.Add(user);
            _context.SaveChanges();
        }

        public Travel Update(int id, Travel user)
        {
            var existingTravel = _context.Travels.FirstOrDefault(c => c.Id == id);

            if (existingTravel == null)
            {
                throw new KeyNotFoundException($"Travel with ID {id} not found.");
            }

            existingTravel.UserId = user.UserId;
            existingTravel.StartPoint = user.StartPoint;
            existingTravel.EndPoint = user.EndPoint;
            existingTravel.RemainingAutonomy = user.RemainingAutonomy;
            existingTravel.CreatedAt = user.CreatedAt;

            _context.Travels.Update(existingTravel);
            _context.SaveChanges();

            return existingTravel;
        }
        
        public void Delete(int id)
        {
            var user = _context.Travels.FirstOrDefault(c => c.Id == id);

            if (user != null)
            {
                _context.Travels.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}