using DomainLayer.Enums;

namespace DomainLayer.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public Gender Gender { get; set; } 
        public string Specialize { get; set; } = null!;
        public byte[]? Image { get; set; }
        public int? AdminId { get; set; }
        public Admin? Admin { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public ICollection<Setting> Settings { get; set; } = new List<Setting>();
    }

}
