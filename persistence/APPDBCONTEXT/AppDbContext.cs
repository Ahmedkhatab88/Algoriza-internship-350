
using DomainLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using persistence.Identity;
using System.Reflection;

namespace persistence.APPDBCONTEXT
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Admin> admins { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<DiscountCodeCoupon> discountCodeCoupons { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<TimeSlot> timeSlots { get; set; }

        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
