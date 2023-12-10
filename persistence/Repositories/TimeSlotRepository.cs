
using ApplicationLayer.NonGenericInterface;
using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using persistence.APPDBCONTEXT;

namespace VEZEETA.Infrastructure.persistence.Repositories
{
    public class TimeSlotRepository : GenericRepository<TimeSlot>, ITimeSlotRepository
    {
        private DbSet<TimeSlot> _TimeSlots;

        public TimeSlotRepository(AppDbContext context) : base(context)
        {
            _TimeSlots = context.Set<TimeSlot>();
        }

    }
}
