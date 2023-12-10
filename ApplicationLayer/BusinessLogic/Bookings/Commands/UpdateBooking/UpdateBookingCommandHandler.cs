

using ApplicationLayer.Exceptions;
using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Bills.Commands.UpdateBill
{
    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, bool>
    {
        private readonly IGenericRepository<Booking> _genericRepository;
        private readonly IMapper _mapper;

        public UpdateBookingCommandHandler(IGenericRepository<Booking> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            var map= _mapper.Map<Booking>(request);

            if (map == null)
            {
                throw new BadRequestException("You can't update null Data");
            }

            await _genericRepository.Update(map);

            return true;
        }
    }
}
