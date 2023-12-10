using MediatR;

namespace ApplicationLayer.BusinessLogic.Settings.Commands.DeactivateCommand
{
    public class DeactivateSettingCommand : IRequest<bool>
    {
        public int id {  get; set; }
    }
}
