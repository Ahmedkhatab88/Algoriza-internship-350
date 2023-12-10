
using ApplicationLayer.Exceptions;
using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.admins.Commands.UpdateAdmin
{
    public class UpdateAdminCommandHandler : IRequestHandler<UpdateAdminCommand, bool>
    {
        private readonly IGenericRepository<Admin> _repository;
        private readonly IMapper _mapper;

        public UpdateAdminCommandHandler(IGenericRepository<Admin> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
        {
            var map = _mapper.Map<Admin>(request);

            if (map == null)
            {
                throw new BadRequestException("You can't update null Data");
            }

            await _repository.Update(map);

            return true;
        }
    }
}
