
using ApplicationLayer.NonGenericInterface;
using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using persistence.APPDBCONTEXT;

namespace VEZEETA.Infrastructure.persistence.Repositories
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        private DbSet<Booking> _Booking;

        public BookingRepository(AppDbContext context) : base(context)
        {
            _Booking = context.Set<Booking>();
        }

    }
}
