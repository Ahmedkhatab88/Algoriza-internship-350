using ApplicationLayer.Exceptions;
using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Settings.Queries.GetSettingList
{
    public class GetSettingListQueryHandler : IRequestHandler<GetSettingListQuery, List<SettingViewModel>>
    {
        private readonly IGenericRepository<Setting> _genericRepository;
        private readonly IMapper _mapper;

        public GetSettingListQueryHandler(IGenericRepository<Setting> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<List<SettingViewModel>> Handle(GetSettingListQuery request, CancellationToken cancellationToken)
        {
            var query = await _genericRepository.GetAll(new[] { "TimeSlot", "Doctor" });

            if (query == null)
            {
                throw new ItemNotFoundException("don't exist Settings");
            }
            var map = _mapper.Map<List<SettingViewModel>>(query);

            return map;
        }


    }
}
