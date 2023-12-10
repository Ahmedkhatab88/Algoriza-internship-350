

using ApplicationLayer.Exceptions;
using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Settings.Commands.UpdateSetting
{
    public class UpdateSettingCommandHandler : IRequestHandler<UpdateSettingCommand, bool>
    {
        private readonly IGenericRepository<Setting> _genericRepository;
        private readonly IMapper _mapper;

        public UpdateSettingCommandHandler(IGenericRepository<Setting> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateSettingCommand request, CancellationToken cancellationToken)
        {
            var map = _mapper.Map<Setting>(request);

            if (map == null)
            {
                throw new BadRequestException("You can't Update null Data");
            }
            await _genericRepository.Update(map);

            return true;
        }
    }
}
