using MediatR;

namespace ApplicationLayer.BusinessLogic.admins.Commands.UpdateAdmin
{
    public class UpdateAdminCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
