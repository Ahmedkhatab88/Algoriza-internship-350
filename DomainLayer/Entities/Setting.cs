namespace DomainLayer.Entities
{
    public class Setting
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = null!;
        public TimeSlot TimeSlot { get; set; } = null!;
    }

}
