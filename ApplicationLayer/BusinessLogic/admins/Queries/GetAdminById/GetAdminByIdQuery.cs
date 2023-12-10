using MediatR;

namespace ApplicationLayer.BusinessLogic.admins.Queries.GetAdminById
{
    public class GetAdminByIdQuery : IRequest<AdminDetailViewModel>
    {
        public int Id { get; set; }
    }
}
