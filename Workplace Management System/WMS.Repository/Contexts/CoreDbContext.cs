using Microsoft.EntityFrameworkCore;
using WMS.Data.Entities.Core;
using WMS.Data.EntityConfigurations.Core;

namespace WMS.Repository.Contexts
{
    public class CoreDbContext : DbContext
    {
        public DbSet<Site> Sites { get; set; } = null!;
        public DbSet<Floor> Floors { get; set; } = null!;
        public DbSet<Workplace> Workplaces { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Reservation> Reservations { get; set; } = null!;

        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new SiteConfiguration());
            modelBuilder.ApplyConfiguration(new FloorConfiguration());
            modelBuilder.ApplyConfiguration(new WorkplaceConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
        }
    }
}
