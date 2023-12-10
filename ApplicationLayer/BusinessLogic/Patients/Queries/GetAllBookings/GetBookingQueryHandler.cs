
using ApplicationLayer.Exceptions;
using ApplicationLayer.NonGenericInterface;
using AutoMapper;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Patients.Queries.GetAllBookings
{
    public class GetBookingQueryHandler : IRequestHandler<GetBookingQuery, List<GetBookingViewModel>>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public GetBookingQueryHandler(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<List<GetBookingViewModel>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
        {
            var query = await _patientRepository.GetAllBookings(request.PatientId);

            if(query == null)
            {
                throw new ItemNotFoundException("Don't exist any Booking belong you.");
            }

            var map = _mapper.Map<List<GetBookingViewModel>>(query);

            return map;
        }
    }
}
