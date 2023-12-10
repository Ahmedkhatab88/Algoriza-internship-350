
using ApplicationLayer.BusinessLogic.admins.Queries.GetTopFiveSpecializations;
using ApplicationLayer.BusinessLogic.admins.Queries.GetTopTenDoctors;
using ApplicationLayer.NonGenericInterface;
using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using persistence.APPDBCONTEXT;

namespace VEZEETA.Infrastructure.persistence.Repositories
{
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        private AppDbContext _dbContext;

        public AdminRepository(AppDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<int> NumOfDoctors()
        {
            var query = _dbContext.admins.Include(x => x.Doctors);

            var count = await query.Select(x => x.Doctors).CountAsync();

            return count;
        }

        public async Task<int> NumOfPatients()
        {
            var query = _dbContext.admins.Include(x => x.Patients);

            var count = await query.Select(x => x.Patients).CountAsync();

            return count;
        }

        public async Task<List<GetTopDoctorsViewModel>> GetTopTenDoctors()
        {
            var query = await _context.Doctors.Include(x => x.Bookings)
                                      .OrderByDescending(x => x.Bookings.Count())
                                      .Take(10)
                                      .Select(x => new GetTopDoctorsViewModel()
                                      {
                                          Id = x.Id,
                                          FullName = x.FullName,
                                          Specialize = x.Specialize,
                                          Image = x.Image,
                                          Requests = x.Bookings.Count()
                                      })
                                      .ToListAsync();

            return query;
        }

        public async Task<int> NumberOfRequests()
        {
            var count = await _dbContext.Bookings.CountAsync();

            return count;
        }

        public async Task<int> NumberOfRequestsLastDay()
        {
            DateTime currentTime = DateTime.Now;
            DateTime previousDay = currentTime.AddDays(-1);

            var count = await _context.timeSlots.CountAsync(x => x.dateTime <= currentTime && x.dateTime >= previousDay);

            return count;
        }

        public async Task<List<SpecializationViewModel>> GetTopFiveSpecializations()
        {
            var query = await _context.Doctors.GroupBy(x => x.Specialize)
                .Select(x => new SpecializationViewModel()
                {
                    specialize = x.Key,
                    count = x.Count()
                })
                .OrderByDescending(g => g.count)
                .Take(5)
                .ToListAsync();

            return query;
        }
    }
}
