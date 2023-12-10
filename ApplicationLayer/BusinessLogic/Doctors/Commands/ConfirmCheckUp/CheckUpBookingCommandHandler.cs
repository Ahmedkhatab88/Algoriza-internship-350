

using ApplicationLayer.NonGenericInterface;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Doctors.Commands.ConfirmCheckUp
{
    public class CheckUpBookingCommandHandler : IRequestHandler<CheckUpBookingCommand,bool>
    {
        private readonly IDoctorRepository _repository;

        public CheckUpBookingCommandHandler(IDoctorRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CheckUpBookingCommand request, CancellationToken cancellationToken)
        {
           await _repository.ConfirmCheckUp(request.BookingId);

            return true;
        }
    }
}
