using DAL.Entities;
using DAL.Helpers;
using Microsoft.EntityFrameworkCore;


namespace DAL.DBContext
{
    public class HotelContext : DbContext
    {
        public HotelContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=WIN-RZAIETS;Database=HotelDB;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<NutritionType> NutritionTypes { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<RatingCriteria> RatingCriterias { get; set; }

    }
}
