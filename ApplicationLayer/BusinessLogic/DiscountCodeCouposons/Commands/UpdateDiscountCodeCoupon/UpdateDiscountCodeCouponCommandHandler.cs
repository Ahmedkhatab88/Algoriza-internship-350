
using ApplicationLayer.Exceptions;
using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.DiscountCodeCoupons.Commands.UpdateDiscountCodeCoupon
{
    public class UpdateDiscountCodeCouponCommandHandler : IRequestHandler<UpdateDiscountCodeCouponCommand, bool>
    {
        private readonly IGenericRepository<DiscountCodeCoupon> _repository;
        private readonly IMapper _mapper;

        public UpdateDiscountCodeCouponCommandHandler(IGenericRepository<DiscountCodeCoupon> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateDiscountCodeCouponCommand request, CancellationToken cancellationToken)
        {
            var map = _mapper.Map<DiscountCodeCoupon>(request);

            if (map == null)
            {
                throw new BadRequestException("You can't update null Data");
            }

            await _repository.Update(map);

            return true;
        }
    }
}
