
using ApplicationLayer.Exceptions;
using ApplicationLayer.GenericInterface;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.DiscountCodeCoupons.Commands.DeleteDiscountCodeCoupon
{
    public class DeleteDiscountCodeCouponCommandHandler : IRequestHandler<DeleteDiscountCodeCouponCommand, bool>
    {
        private readonly IGenericRepository<DiscountCodeCoupon> _repository;

        public DeleteDiscountCodeCouponCommandHandler(IGenericRepository<DiscountCodeCoupon> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteDiscountCodeCouponCommand request, CancellationToken cancellationToken)
        {
            var query = await _repository.GetById(request.Id);

            if (query == null)
            {
                throw new ItemNotFoundException("this coupon is not exist");
            }

            await _repository.Delete(query);

            return true;
        }
    }
}
