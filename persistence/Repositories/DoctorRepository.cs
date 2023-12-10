
using ApplicationLayer.NonGenericInterface;
using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using persistence.APPDBCONTEXT;
using System.Net;

namespace VEZEETA.Infrastructure.persistence.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        private AppDbContext _appDbContext;
        public DoctorRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }

        public AppDbContext AppDbContext
        {
            get => _appDbContext;
            set => _appDbContext = value;
        }

        public async Task<bool> ConfirmCheckUp(int BookId)
        {
            var booking = await _appDbContext.Bookings.FindAsync(BookId);

            if (booking == null)
            {
                throw new ArgumentException("Booking not found.");
            }

            // Perform necessary steps for confirming the check-up

            booking.Status = "Confirmed";

            await _appDbContext.SaveChangesAsync();

            return true;
        }
    }
}
