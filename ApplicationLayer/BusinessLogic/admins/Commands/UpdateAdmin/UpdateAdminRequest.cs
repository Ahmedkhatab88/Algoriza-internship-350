namespace ApplicationLayer.BusinessLogic.admins.Commands.UpdateAdmin
{
    public class UpdateAdminRequest 
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
