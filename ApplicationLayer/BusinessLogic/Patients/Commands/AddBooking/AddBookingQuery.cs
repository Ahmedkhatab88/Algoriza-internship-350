using MediatR;

namespace ApplicationLayer.BusinessLogic.Patients.Commands.AddBooking
{
    public class AddBookingQuery : IRequest<bool>
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string status { get; set; } = null!;
    }
}
