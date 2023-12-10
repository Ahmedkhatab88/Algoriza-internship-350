

namespace ApplicationLayer.BusinessLogic.Patients.Commands.UpdatePatient
{
    public class UpdatePatientRequest
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string DateOfBirth { get; set; } = null!;
        public byte[]? Image { get; set; }
        public int? AdminId { get; set; }
    }
}
