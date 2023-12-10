using MediatR;

namespace ApplicationLayer.BusinessLogic.admins.Queries.GetTopFiveSpecializations
{
    public class TopFiveSpecializationsQuery : IRequest<List<SpecializationViewModel>>
    {
    }
}
