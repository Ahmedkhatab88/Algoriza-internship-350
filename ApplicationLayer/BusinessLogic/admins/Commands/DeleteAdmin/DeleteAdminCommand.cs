using MediatR;

namespace ApplicationLayer.BusinessLogic.admins.Commands.DeleteAdmin
{
    public class DeleteAdminCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
