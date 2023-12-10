using ApplicationLayer.Exceptions;
using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Settings.Queries.GetSettingById
{
    public class GetSettingQueryHandler : IRequestHandler<GetSettingQuery, SettingDetailViewModel>
    {
        private readonly IGenericRepository<Setting> _genericRepository;
        private readonly IMapper _mapper;

        public GetSettingQueryHandler(IGenericRepository<Setting> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<SettingDetailViewModel> Handle(GetSettingQuery request, CancellationToken cancellationToken)
        {
            var query = await _genericRepository.GetById(request.id);

            if (query == null)
            {
                throw new ItemNotFoundException("Item is not exist");
            }
            var map = _mapper.Map<SettingDetailViewModel>(query);

            return map;
        }

    }
}
