using MediatR;

namespace ApplicationLayer.BusinessLogic.admins.Commands.AddAdmin
{
    public class AddAdminCommand : IRequest<bool>
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
