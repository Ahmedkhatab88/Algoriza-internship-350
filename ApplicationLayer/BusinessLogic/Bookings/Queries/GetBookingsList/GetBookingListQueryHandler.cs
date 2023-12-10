using ApplicationLayer.Exceptions;
using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Bills.Queries.GetBillsList
{
    public class GetBookingListQueryHandler : IRequestHandler<GetBookingListQuery, List<BookingViewModel>>
    {
        private readonly IGenericRepository<Booking> _genericRepository;
        private readonly IMapper _mapper;

        public GetBookingListQueryHandler(IGenericRepository<Booking> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<List<BookingViewModel>> Handle(GetBookingListQuery request, CancellationToken cancellationToken)
        {
            var query = await _genericRepository.GetAll(new[] { "Patient", "Doctor" });

            if (query == null)
            {
                throw new ItemNotFoundException("not exist bookings");
            }

            var map = _mapper.Map<List<BookingViewModel>>(query);

            return map;
        }
    }
}
