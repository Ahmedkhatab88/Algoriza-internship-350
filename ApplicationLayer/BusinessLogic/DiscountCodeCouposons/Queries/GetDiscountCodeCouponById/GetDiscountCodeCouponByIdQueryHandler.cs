
using ApplicationLayer.Exceptions;
using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.DiscountCodeCoupons.Queries.GetDiscountCodeCouponById
{
    public class GetDiscountCodeCouponByIdQueryHandler : IRequestHandler<GetDiscountCodeCouponByIdQuery, DiscountCodeCouponDetailedViewModel>
    {
        private readonly IGenericRepository<DiscountCodeCoupon> _repository;
        private readonly IMapper _mapper;

        public GetDiscountCodeCouponByIdQueryHandler(IGenericRepository<DiscountCodeCoupon> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DiscountCodeCouponDetailedViewModel> Handle(GetDiscountCodeCouponByIdQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.GetById(request.Id);

            if(query is null)
            {
                throw new ItemNotFoundException("item is not found");
            }

            var map = _mapper.Map<DiscountCodeCouponDetailedViewModel>(query);

            return map;
        }

    }
}
