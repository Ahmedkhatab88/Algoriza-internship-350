
using ApplicationLayer.Exceptions;
using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Bills.Commands.DeleteBill
{
    public class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand, bool>
    {
        private readonly IGenericRepository<Booking> _genericRepository;
        private readonly IMapper _mapper;

        public DeleteBookingCommandHandler(IGenericRepository<Booking> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            var query = await _genericRepository.GetById(request.id);
           
            if (query == null)
            {
                throw new ItemNotFoundException("this is not exist");
            }

            await _genericRepository.Delete(query);

            return true;
        }
    }
}
