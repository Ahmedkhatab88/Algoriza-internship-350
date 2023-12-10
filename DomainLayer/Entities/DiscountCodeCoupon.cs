using DomainLayer.Enums;

namespace DomainLayer.Entities
{
    public class DiscountCodeCoupon
    {
        public int Id { get; set; }
        public string DiscountCode { get; set; } = null!;
        public DiscountType DiscountType { get; set; }
        public decimal Value { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;

    }

}
