
using ApplicationLayer.BusinessLogic.Bills.Queries.GetBillsList;

namespace ApplicationLayer.BusinessLogic.DiscountCodeCoupons.Queries.GetDiscountCodeCouponList
{
    public class DiscountCodeCouponViewModel
    {
        public int Id { get; set; }
        public string DiscountCode { get; set; } = null!;
        public string DiscountType { get; set; } = null!;
        public decimal Value { get; set; }
        public int PatientId { get; set; }
        public PatientDTO Patient { get; set; } = null!;
    }
}
