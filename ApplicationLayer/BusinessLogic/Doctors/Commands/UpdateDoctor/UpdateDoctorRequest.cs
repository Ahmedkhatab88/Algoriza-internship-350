
using DomainLayer.Entities;

namespace ApplicationLayer.BusinessLogic.Doctors.Commands.UpdateDoctor
{
    public class UpdateDoctorRequest
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string Specialize { get; set; } = null!;
        public byte[]? Image { get; set; }
        public int? AdminId { get; set; }
    }
}
