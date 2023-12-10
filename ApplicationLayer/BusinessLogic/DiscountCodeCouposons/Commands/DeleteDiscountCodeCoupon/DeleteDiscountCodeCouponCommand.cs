using MediatR;

namespace ApplicationLayer.BusinessLogic.DiscountCodeCoupons.Commands.DeleteDiscountCodeCoupon
{
    public class DeleteDiscountCodeCouponCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
