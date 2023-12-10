
using ApplicationLayer.Exceptions;
using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Bills.Commands.AddBill
{
    public class AddBookingCommandHandler : IRequestHandler<AddBookingCommand, int>
    {
        private readonly IGenericRepository<Booking> _genericRepository;
        private readonly IMapper _mapper;

        public AddBookingCommandHandler(IGenericRepository<Booking> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddBookingCommand request, CancellationToken cancellationToken)
        {
            var map= _mapper.Map<Booking>(request);

            if (map == null)
            {
                throw new BadRequestException("You can't add null Data");
            }
            await _genericRepository.Add(map);

            return map.Id;
        }
    }
}
