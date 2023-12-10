using MediatR;

namespace ApplicationLayer.BusinessLogic.admins.Queries.GetAdminsList
{
    public class GetAdminListQuery : IRequest<List<AdminViewModel>>
    {
    }
}
