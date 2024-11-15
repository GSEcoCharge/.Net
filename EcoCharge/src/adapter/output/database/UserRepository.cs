using EcoCharge.domain.model;
using EcoCharge.domain.repository;

namespace EcoCharge.adapter.output.database
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public User FindById(int id)
        {
            var user = _context.Users.FirstOrDefault(c => c.Id == id);

            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }

            return user;
        }

        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User Update(int id, User user)
        {
            var existingUser = _context.Users.FirstOrDefault(c => c.Id == id);

            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.ProfileImage = user.ProfileImage;
            existingUser.CreatedAt = user.CreatedAt;
            existingUser.LastLocation = user.LastLocation;

            _context.Users.Update(existingUser);
            _context.SaveChanges();

            return existingUser;
        }
        
        public void Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(c => c.Id == id);

            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}