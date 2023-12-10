using ApplicationLayer.Exceptions;
using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Patients.Queries.GetPatientList
{
    public class GetPatientListQueryHandler : IRequestHandler<GetPatientListQuery, List<PatientViewModel>>
    {
        private readonly IGenericRepository<Patient> _genericRepository;
        private readonly IMapper _mapper;

        public GetPatientListQueryHandler(IGenericRepository<Patient> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<List<PatientViewModel>> Handle(GetPatientListQuery request, CancellationToken cancellationToken)
        {
            var query = await _genericRepository.GetAll();

            if (query == null)
            {
                throw new ItemNotFoundException("don't exist Patients");
            }

            var map = _mapper.Map<List<PatientViewModel>>(query);

            return map;
        }
    }
}
