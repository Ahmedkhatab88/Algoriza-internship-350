using MediatR;

namespace ApplicationLayer.BusinessLogic.Settings.Queries.GetSettingById
{
    public class GetSettingQuery : IRequest<SettingDetailViewModel>
    {
        public int id { get; set; }

    }
}