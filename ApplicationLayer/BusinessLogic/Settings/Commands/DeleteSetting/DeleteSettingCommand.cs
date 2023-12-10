using MediatR;

namespace ApplicationLayer.BusinessLogic.Settings.Commands.DeleteSetting
{
    public class DeleteSettingCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

}
