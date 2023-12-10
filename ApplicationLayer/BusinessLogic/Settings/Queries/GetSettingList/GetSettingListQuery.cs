using MediatR;

namespace ApplicationLayer.BusinessLogic.Settings.Queries.GetSettingList
{
    public class GetSettingListQuery : IRequest<List<SettingViewModel>>
    {

    }
}
