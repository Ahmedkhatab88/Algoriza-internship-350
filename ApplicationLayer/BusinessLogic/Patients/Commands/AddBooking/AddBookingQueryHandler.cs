

using ApplicationLayer.NonGenericInterface;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Patients.Commands.AddBooking
{
    public class AddBookingQueryHandler : IRequestHandler<AddBookingQuery, bool>
    {
        private readonly IPatientRepository _patientRepository;

        public AddBookingQueryHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<bool> Handle(AddBookingQuery request, CancellationToken cancellationToken)
        {
            await _patientRepository.Booking(request.PatientId,request.DoctorId,request.status);

            return true;
        }
    }
}
