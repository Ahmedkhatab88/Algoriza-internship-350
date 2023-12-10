

using ApplicationLayer.GenericInterface;
using DomainLayer.Entities;

namespace ApplicationLayer.NonGenericInterface
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        Task<List<Doctor>> GetAllDoctors(int PageNumber,int PageSize);
        Task<List<Patient>> GetAllBookings(int patientId);
        Task CancelBooking(int BookId);
        Task Booking(int patientId,int doctorId,string status);
    }

}
