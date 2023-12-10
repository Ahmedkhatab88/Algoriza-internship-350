

using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Patients.Commands.AddPatient
{
    public class AddPatientCommandHandler : IRequestHandler<AddPatientCommand, bool>
    {
        private readonly IGenericRepository<Patient> _genericRepository;
        private readonly IMapper _mapper;

        public AddPatientCommandHandler(IGenericRepository<Patient> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(AddPatientCommand request, CancellationToken cancellationToken)
        {
            var map = _mapper.Map<Patient>(request);

            await _genericRepository.Add(map);

            return true;
        }
    }
}
