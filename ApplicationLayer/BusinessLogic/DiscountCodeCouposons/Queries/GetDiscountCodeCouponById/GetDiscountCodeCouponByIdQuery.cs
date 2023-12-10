using MediatR;

namespace ApplicationLayer.BusinessLogic.DiscountCodeCoupons.Queries.GetDiscountCodeCouponById
{
    public class GetDiscountCodeCouponByIdQuery : IRequest<DiscountCodeCouponDetailedViewModel>
    {
        public int Id { get; set; }
    }
}
