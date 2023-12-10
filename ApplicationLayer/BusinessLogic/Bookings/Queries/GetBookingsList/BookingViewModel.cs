using ApplicationLayer.BusinessLogic.Bookings.Queries.GetBookingsList;

namespace ApplicationLayer.BusinessLogic.Bills.Queries.GetBillsList
{
    public class BookingViewModel
    {
        public int Id { get; set; }
        public string Status { get; set; } = null!;
        public int PatientId { get; set; }
        public PatientDTO Patient { get; set; } = null!;
        public int DoctorId { get; set; }
        public DoctorDTO Doctor { get; set; } = null!;
    }
}
