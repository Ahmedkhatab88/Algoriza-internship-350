

namespace ApplicationLayer.BusinessLogic.Patients.Queries.GetAllDoctors
{
    public class DoctorSearchViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string Specialize { get; set; } = null!;
        public byte[]? Image { get; set; }
        public ICollection<SettingDTO> Settings { get; set; } = new List<SettingDTO>();

    }
}
