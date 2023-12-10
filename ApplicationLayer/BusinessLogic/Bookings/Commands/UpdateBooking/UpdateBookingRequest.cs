

using ApplicationLayer.BusinessLogic.Bills.Queries.GetBillsList;
using ApplicationLayer.BusinessLogic.Bookings.Queries.GetBookingsList;

namespace ApplicationLayer.BusinessLogic.Bills.Commands.UpdateBill
{
    public class UpdateBookingRequest
    {
        public string Status { get; set; } = null!;
        public int PatientId { get; set; }
        public PatientDTO Patient { get; set; } = null!;
        public int DoctorId { get; set; }
        public DoctorDTO Doctor { get; set; } = null!;
    }
}
