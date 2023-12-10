

using ApplicationLayer.BusinessLogic.Bills.Queries.GetBillsList;
using ApplicationLayer.BusinessLogic.Bookings.Queries.GetBookingsList;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Bills.Commands.AddBill
{
    public class AddBookingCommand : IRequest<int>
    {
        public string Status { get; set; } = null!;
        public int PatientId { get; set; }
        public PatientDTO Patient { get; set; } = null!;
        public int DoctorId { get; set; }
        public DoctorDTO Doctor { get; set; } = null!;
    }
}
