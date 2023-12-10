

using ApplicationLayer.Exceptions;
using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Doctors.Commands.DeleteDoctor
{
    public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand, bool>
    {
        private readonly IGenericRepository<Doctor> _genericRepository;
        private readonly IMapper _mapper;

        public DeleteDoctorCommandHandler(IGenericRepository<Doctor> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            var query = await _genericRepository.GetById(request.id);

            if (query == null)
            {
                throw new ItemNotFoundException("this doctor is not exist");
            }

            await _genericRepository.Delete(query);

            return true;
        }
    }
}
