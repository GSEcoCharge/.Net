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
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User -> Vehicle (1..N)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Vehicles)
                .WithOne()
                .HasForeignKey(v => v.UserId);

            // User -> Travel (1..N)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Travels)
                .WithOne()
                .HasForeignKey(t => t.UserId);

            // Travel -> StopingPoint (1..N)
            modelBuilder.Entity<Travel>()
                .HasMany(t => t.StopingPoints)
                .WithOne()
                .HasForeignKey(sp => sp.TravelId);

            // User -> Evaluation (1..N)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Evaluations)
                .WithOne()
                .HasForeignKey(e => e.UserId);

            // ChargingPost -> Evaluation (1..N)
            modelBuilder.Entity<ChargingPost>()
                .HasMany(cp => cp.Evaluations)
                .WithOne()
                .HasForeignKey(e => e.ChargingPostId);

            // ChargingPost -> ChargingPoint (1..N)
            modelBuilder.Entity<ChargingPost>()
                .HasMany(cp => cp.ChargingPoints)
                .WithOne()
                .HasForeignKey(cp => cp.ChargingStationId);

            // User -> ChargingHistory (1..N)
            modelBuilder.Entity<User>()
                .HasMany(u => u.ChargingHistories)
                .WithOne()
                .HasForeignKey(ch => ch.UserId);

            // User -> Booking (1..N)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Bookings)
                .WithOne()
                .HasForeignKey(b => b.UserId);

            // ChargingPoint -> Booking (1..N)
            modelBuilder.Entity<ChargingPoint>()
                .HasMany(cp => cp.Bookings)
                .WithOne()
                .HasForeignKey(b => b.ChargingPointId);
        }
    }
}