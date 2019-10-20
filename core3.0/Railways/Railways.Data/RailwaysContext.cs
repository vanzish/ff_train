using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Railways.Entities;
using Railways.Entities.Interfaces;

namespace Railways.Data
{
    public class RailwaysContext : DbContext
    {
        public DbSet<Route> Routes { get; set; }
        public DbSet<RoutePoint> RoutePoints { get; set; }
        public DbSet<Run> Runs { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<Carriage> Carriages { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<SeatType> SeatTypes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Configuration> Configuration { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Railways;Username=postgres;Password=password");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasOne<RoutePoint>(x => x.ArrivalRoutePoint).WithMany(x => x.ArrivalTickets)
                      .HasForeignKey(x => x.ArrivalRoutePointId);
                entity.HasOne<RoutePoint>(x => x.DepartureRoutePoint).WithMany(x => x.DepartureTickets)
                      .HasForeignKey(x => x.DepartureRoutePointId);
            });
            modelBuilder.Seed();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is IDateCreated created && entry.State == EntityState.Added)
                {
                    created.CreatedAt = DateTime.UtcNow;
                }

                if (entry.Entity is IDateUpdated updated && entry.State == EntityState.Modified)
                {
                    updated.LastUpdatedAt = DateTime.UtcNow;
                }
            }
        }
    }
}