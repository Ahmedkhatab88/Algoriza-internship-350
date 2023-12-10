
using ApplicationLayer.NonGenericInterface;
using DomainLayer.Entities;
using DomainLayer.Enums;
using Microsoft.EntityFrameworkCore;
using persistence.APPDBCONTEXT;

namespace VEZEETA.Infrastructure.persistence.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        private AppDbContext _appDbContext;
        public PatientRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public AppDbContext AppDbContext
        {
            get => _appDbContext;
            set => _appDbContext = value;
        }

        public async Task Booking(int patientId, int doctorId, string status)
        {
            var patient = await _appDbContext.Patients.Include(p => p.bookings).SingleOrDefaultAsync(p => p.Id == patientId);

            if (patient != null)
            {
                var bookingCount = patient.bookings.Count();

                if (bookingCount % 5 == 0)
                {
                    var discountCodeCoupon = new DiscountCodeCoupon
                    {
                        DiscountCode = "C009",
                        DiscountType = DiscountType.Value,
                        Value = 200
                    };

                    patient.DiscountCodeCoupon = discountCodeCoupon;
                    patient.DiscountCodeCouponId = discountCodeCoupon.Id;
                }

                var booking = new Booking
                {
                    PatientId = patientId,
                    DoctorId = doctorId,
                    Status = status
                };

                _appDbContext.Bookings.Add(booking);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task CancelBooking(int bookingId)
        {
            var bookingToRemove = await _appDbContext.Bookings.FindAsync(bookingId);

            if (bookingToRemove != null)
            {
                _appDbContext.Bookings.Remove(bookingToRemove);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Patient>> GetAllBookings(int patientId)
        {
            var query = await _appDbContext.Patients.Where(x => x.Id == patientId).Include(x => x.bookings).ThenInclude(x => x.Doctor)
                .ToListAsync();

            return query;
        }

        public async Task<List<Doctor>> GetAllDoctors(int pageNumber, int pageSize)
        {
            var query = _appDbContext.Doctors.Include(x => x.Settings);

            if (query == null)
            {
                throw new Exception("No doctors exist.");
            }

            var pagination = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return pagination;
        }
        //private DbSet<Patient> _patients;

        //public PatientRepository(AppDbContext context) : base(context)
        //{
        //    _patients = context.Set<Patient>();
        //}

        //private AppDbContext _appDbContext;

        //public PatientRepository(AppDbContext appDbContext) : base(appDbContext) 
        //{
        //    _appDbContext = appDbContext;
        //}

        //public AppDbContext AppDbContext
        //{
        //    get => _appDbContext;
        //    set => _appDbContext = value;
        //}

        //public Task Booking(int patientId)
        //{
        //    throw new NotImplementedException();
        //}

        ////public Task Booking(int PatientId)
        ////{
        ////    var patient = _patients.Include(p => p.Bookings).SingleOrDefault(p => p.Id == PatientId);

        ////    if (patient != null)
        ////    {
        ////        var bookingCount = patient.Bookings.Count();
        ////        if (bookingCount % 5 == 0)
        ////        {
        ////            var discountCodeCoupon = new DiscountCodeCoupon
        ////            {
        ////                DiscountCode = "C009",
        ////                DiscountType = "decrease",
        ////                Value = 200  
        ////            };

        ////            patient.DiscountCodeCoupon = discountCodeCoupon;
        ////        }

        ////        var booking = new Booking
        ////        {
        ////            PatientId = PatientId,
        ////            Patient = patient,

        ////        };

        ////        _context.Bookings.Add(booking);
        ////        _context.SaveChanges();
        ////    }
        ////}

        //public async Task CancelBooking(int BookId)
        //{
        //    var patient = _appDbContext.Patients.Include(p => p.bookings);

        //    if (patient != null)
        //    {
        //        var bookingToRemove = patient.bookings.FirstOrDefault(b => b.Id == BookId);

        //        if (bookingToRemove != null)
        //        {
        //            patient.bookings.Remove(bookingToRemove);
        //            await _context.SaveChangesAsync();
        //        }
        //    }

        //}


        //public async Task<List<Patient>> GetAllBookings(int patientId)
        //{
        //    var query = await _appDbContext.Patients.Where(x=> x.Id == patientId).Include(x => x.bookings).ThenInclude(x=> x.Doctor)
        //        .ToListAsync();

        //    return query;
        //}

        //public async Task<List<Doctor>> GetAllDoctors(int PageNumber,int PageSize)
        //{
        //    var query = _context.Set<Doctor>().Include(x=> x.Settings).ToListAsync();

        //    if(query == null)
        //    {
        //        throw new Exception("not exist Doctors");
        //    }

        //    var pagination = await query.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();

        //    return pagination;
        //}
    }
}
