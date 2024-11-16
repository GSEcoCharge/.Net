using Microsoft.EntityFrameworkCore;
using EcoCharge.domain.model;

namespace EcoCharge.adapter.output.database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<ChargingPoint> ChargingPoints { get; set; }
        public DbSet<ChargingPost> ChargingPosts { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<ChargingHistory> ChargingHistories { get; set; }
        public DbSet<StopingPoint> StopingPoints { get; set; }
    }
}