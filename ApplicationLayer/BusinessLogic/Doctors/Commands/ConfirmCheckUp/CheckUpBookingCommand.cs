using MediatR;

namespace ApplicationLayer.BusinessLogic.Doctors.Commands.ConfirmCheckUp
{
    public class CheckUpBookingCommand : IRequest<bool>
    {
        public int BookingId { get; set; }
    }
}
