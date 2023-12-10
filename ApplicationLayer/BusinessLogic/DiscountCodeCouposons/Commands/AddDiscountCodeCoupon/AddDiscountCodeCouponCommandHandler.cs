

using ApplicationLayer.Exceptions;
using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.DiscountCodeCoupons.Commands.AddDiscountCodeCoupon
{
    public class AddDiscountCodeCouponCommandHandler : IRequestHandler<AddDiscountCodeCouponCommand, bool>
    {
        private readonly IGenericRepository<DiscountCodeCoupon> _repository;
        private readonly IMapper _mapper;

        public AddDiscountCodeCouponCommandHandler(IGenericRepository<DiscountCodeCoupon> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(AddDiscountCodeCouponCommand request, CancellationToken cancellationToken)
        {
            var map = _mapper.Map<DiscountCodeCoupon>(request);

            if (map == null)
            {
                throw new BadRequestException("You can't add null Data");
            }

            await _repository.Add(map);

            return true;
        }
    }
}
