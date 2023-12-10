using MediatR;

namespace ApplicationLayer.BusinessLogic.admins.Queries.GetTopTenDoctors
{
    public class GetTopTenDoctorsQuery : IRequest<List<GetTopDoctorsViewModel>>
    {
    }
}
