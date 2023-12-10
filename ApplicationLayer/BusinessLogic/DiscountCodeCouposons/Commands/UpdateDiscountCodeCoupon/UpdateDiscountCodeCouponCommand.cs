using ApplicationLayer.BusinessLogic.Bills.Queries.GetBillsList;
using MediatR;

namespace ApplicationLayer.BusinessLogic.DiscountCodeCoupons.Commands.UpdateDiscountCodeCoupon
{
    public class UpdateDiscountCodeCouponCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string DiscountCode { get; set; } = null!;
        public string DiscountType { get; set; } = null!;
        public decimal Value { get; set; }
        public int PatientId { get; set; }
        public PatientDTO Patient { get; set; } = null!;
    }
}
