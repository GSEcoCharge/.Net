using EcoCharge.domain.model;
using EcoCharge.domain.repository;

namespace EcoCharge.adapter.output.database
{
    public class ChargingPostRepository : IChargingPostRepository
    {
        private readonly ApplicationDbContext _context;

        public ChargingPostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ChargingPost FindById(string id)
        {
            return _context.ChargingPosts.FirstOrDefault(c => c.Id == id);
        }

        public void Create(ChargingPost chargingPost)
        {
            _context.ChargingPosts.Add(chargingPost);
            _context.SaveChanges();
        }

        public ChargingPost Update(string id, ChargingPost chargingPost)
        {
            var existingChargingPost = _context.ChargingPosts.FirstOrDefault(c => c.Id == id);

            if (existingChargingPost == null)
            {
                throw new KeyNotFoundException($"ChargingPost with ID {id} not found.");
            }

            existingChargingPost.Name = chargingPost.Name;
            existingChargingPost.Latitude = chargingPost.Latitude;
            existingChargingPost.Longitude = chargingPost.Longitude;
            existingChargingPost.Address = chargingPost.Address;
            existingChargingPost.OpenHours = chargingPost.OpenHours;
            existingChargingPost.PaymentMethods = chargingPost.PaymentMethods;
            existingChargingPost.AvarageRating = chargingPost.AvarageRating;

            _context.ChargingPosts.Update(existingChargingPost);
            _context.SaveChanges();

            return existingChargingPost;
        }
        
        public void Delete(string id)
        {
            var chargingPost = _context.ChargingPosts.FirstOrDefault(c => c.Id == id);

            if (chargingPost != null)
            {
                _context.ChargingPosts.Remove(chargingPost);
                _context.SaveChanges();
            }
        }
    }
}