using ApplicationLayer.BusinessLogic.Bills.Queries.GetBillsList;
using DomainLayer.Entities;

namespace ApplicationLayer.BusinessLogic.DiscountCodeCoupons.Commands.UpdateDiscountCodeCoupon
{
    public class UpdateDiscountCodeCouponRequest
    {
        public string DiscountCode { get; set; } = null!;
        public string DiscountType { get; set; } = null!;
        public decimal Value { get; set; }
        public int PatientId { get; set; }
        public PatientDTO Patient { get; set; } = null!;
    }
}
