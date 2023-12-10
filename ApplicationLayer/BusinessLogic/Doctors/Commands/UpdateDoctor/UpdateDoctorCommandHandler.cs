

using ApplicationLayer.Exceptions;
using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Doctors.Commands.UpdateDoctor
{
    public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, bool>
    {
        private readonly IGenericRepository<Doctor> _genericRepository;
        private readonly IMapper _mapper;

        public UpdateDoctorCommandHandler(IGenericRepository<Doctor> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            var map= _mapper.Map<Doctor>(request);

            if (map == null)
            {
                throw new BadRequestException("You can't Update null Data");
            }

            await _genericRepository.Update(map);

            return true;
        }
    }
}
