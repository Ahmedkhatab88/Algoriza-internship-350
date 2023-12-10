
using MediatR;

namespace ApplicationLayer.BusinessLogic.DiscountCodeCoupons.Queries.GetDiscountCodeCouponList
{
    public class GetDiscountCodeCouponListQuery : IRequest<List<DiscountCodeCouponViewModel>>
    {
    }
}
