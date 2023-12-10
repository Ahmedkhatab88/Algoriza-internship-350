

using ApplicationLayer.BusinessLogic.Bookings.Queries.GetBookingsList;

namespace ApplicationLayer.BusinessLogic.Patients.Queries.GetAllBookings
{
    public class GetBookingViewModel
    {
        public int Id { get; set; }
        public string Status { get; set; } = null!;
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DoctorDTO Doctor { get; set; } = null!;
    }
}
