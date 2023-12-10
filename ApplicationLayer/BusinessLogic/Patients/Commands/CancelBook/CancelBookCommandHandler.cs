

using ApplicationLayer.NonGenericInterface;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Patients.Commands.CancelBook
{
    public class CancelBookCommandHandler : IRequestHandler<CancelBookCommand, bool>
    {
        private readonly IPatientRepository _patientRepository;

        public CancelBookCommandHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<bool> Handle(CancelBookCommand request, CancellationToken cancellationToken)
        {
            await _patientRepository.CancelBooking(request.BookId);

            return true;
        }
    }
}
