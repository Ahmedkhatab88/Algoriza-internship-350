using MediatR;

namespace ApplicationLayer.BusinessLogic.DiscountCodeCoupons.Commands.AddDiscountCodeCoupon
{
    public class AddDiscountCodeCouponCommand : IRequest<bool>
    {
        public string DiscountCode { get; set; } = null!;
        public string DiscountType { get; set; } = null!;
        public decimal Value { get; set; }
        public int PatientId { get; set; }
    }
}
