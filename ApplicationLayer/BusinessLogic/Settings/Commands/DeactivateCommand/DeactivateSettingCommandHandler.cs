

using ApplicationLayer.NonGenericInterface;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Settings.Commands.DeactivateCommand
{
    public class DeactivateSettingCommandHandler : IRequestHandler<DeactivateSettingCommand, bool>
    {
        private readonly ISettingRepository _settingRepository;

        public DeactivateSettingCommandHandler(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }

        public async Task<bool> Handle(DeactivateSettingCommand request, CancellationToken cancellationToken)
        {
            var query = await _settingRepository.Deactivate(request.id);

            return true;
        }
    }
}
