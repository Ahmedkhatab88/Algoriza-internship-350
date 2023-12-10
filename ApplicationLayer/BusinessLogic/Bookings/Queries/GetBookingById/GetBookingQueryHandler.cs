

using ApplicationLayer.Exceptions;
using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Bills.Queries.GetBillsById
{
    public class GetBookingQueryHandler : IRequestHandler<GetBookingQuery, BookingDetailViewModel>
    {
        private readonly IGenericRepository<Booking> _genericRepository;
        private readonly IMapper _mapper;

        public GetBookingQueryHandler(IGenericRepository<Booking> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<BookingDetailViewModel> Handle(GetBookingQuery request, CancellationToken cancellationToken)
        {
            var query = await _genericRepository.GetById(request.id);

            if (query == null)
            {
                throw new ItemNotFoundException("booking is not exist");
            }
            var map= _mapper.Map<BookingDetailViewModel>(query);

            return map;
        }
    }
}
