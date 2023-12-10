

namespace ApplicationLayer.BusinessLogic.admins.Queries.GetAdminsList
{
    public class AdminViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
