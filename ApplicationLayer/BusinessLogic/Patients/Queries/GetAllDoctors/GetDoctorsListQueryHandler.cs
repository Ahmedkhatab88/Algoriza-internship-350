

using ApplicationLayer.Exceptions;
using ApplicationLayer.NonGenericInterface;
using AutoMapper;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Patients.Queries.GetAllDoctors
{
    public class GetDoctorsListQueryHandler : IRequestHandler<GetDoctorsListQuery, List<DoctorSearchViewModel>>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public GetDoctorsListQueryHandler(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<List<DoctorSearchViewModel>> Handle(GetDoctorsListQuery request, CancellationToken cancellationToken)
        {
            var query = await _patientRepository.GetAllDoctors(request.NumberPage, request.SizePage);

            if(query is null)
            {
                throw new ItemNotFoundException("Not exist doctors");
            }

            var map = _mapper.Map<List<DoctorSearchViewModel>>(query);

            return map;
        }
    }
}
