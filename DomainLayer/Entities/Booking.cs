namespace DomainLayer.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public string Status { get; set; } = null!;
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = null!;
    }

}
