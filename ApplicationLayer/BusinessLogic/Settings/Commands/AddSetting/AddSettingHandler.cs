using ApplicationLayer.Exceptions;
using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Settings.Commands.AddSetting
{
    public class AddSettingHandler : IRequestHandler<AddSettingCommand, int>
    {
        private readonly IGenericRepository<Setting> _repository;
        private readonly IMapper _mapper;

        public AddSettingHandler(IGenericRepository<Setting> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddSettingCommand request, CancellationToken cancellationToken)
        {
            var map = _mapper.Map<Setting>(request);

            if (map == null)
            {
                throw new BadRequestException("You can't add null Data");
            }

            var query = await _repository.Add(map);

            return query.Id;
        }
    }
}
