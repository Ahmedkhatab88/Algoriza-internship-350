
using ApplicationLayer.Exceptions;
using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.DiscountCodeCoupons.Queries.GetDiscountCodeCouponList
{
    public class GetDiscountCodeCouponListQueryHandler : IRequestHandler<GetDiscountCodeCouponListQuery, List<DiscountCodeCouponViewModel>>
    {
        private readonly IGenericRepository<DiscountCodeCoupon> _repository;
        private readonly IMapper _mapper;

        public GetDiscountCodeCouponListQueryHandler(IGenericRepository<DiscountCodeCoupon> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<DiscountCodeCouponViewModel>> Handle(GetDiscountCodeCouponListQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.GetAll();

            if(query == null)
            {
                throw new ItemNotFoundException("not exist items");
            }

            var map = _mapper.Map<List<DiscountCodeCouponViewModel>>(query);

            return map;
        }
    }
}
