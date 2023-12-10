

namespace ApplicationLayer.BusinessLogic.admins.Queries.GetAdminById
{
    public class AdminDetailViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
