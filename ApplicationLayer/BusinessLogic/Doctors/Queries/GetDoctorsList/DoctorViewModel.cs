using ApplicationLayer.BusinessLogic.admins.Queries.GetAdminsList;

namespace ApplicationLayer.BusinessLogic.Doctors.Queries.GetDoctorsList
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string Specialize { get; set; } = null!;
        public byte[]? Image { get; set; }
        public int? AdminId { get; set; }
    }
}
