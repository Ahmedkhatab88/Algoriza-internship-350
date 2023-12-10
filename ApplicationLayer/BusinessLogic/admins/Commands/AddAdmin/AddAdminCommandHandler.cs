
using ApplicationLayer.Exceptions;
using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.admins.Commands.AddAdmin
{
    public class AddAdminCommandHandler : IRequestHandler<AddAdminCommand, bool>
    {
        private readonly IGenericRepository<Admin> _repository;
        private readonly IMapper _mapper;

        public AddAdminCommandHandler(IGenericRepository<Admin> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(AddAdminCommand request, CancellationToken cancellationToken)
        {
            var map = _mapper.Map<Admin>(request);

            if (map == null)
            {
                throw new BadRequestException("You can't add null Data");
            }

            var command = await _repository.Add(map);

            return true;
        }
    }
}
