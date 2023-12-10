using DomainLayer.Enums;

namespace DomainLayer.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public Gender Gender { get; set; } 
        public string DateOfBirth { get; set; } = null!;
        public byte[]? Image { get; set; }
        public int? AdminId { get; set; }
        public Admin? Admin { get; set; }
        public int? DiscountCodeCouponId { get; set; }
        public DiscountCodeCoupon? DiscountCodeCoupon { get; set; }
        public ICollection<Booking> bookings { get; set; } = new List<Booking>();
    }

}
