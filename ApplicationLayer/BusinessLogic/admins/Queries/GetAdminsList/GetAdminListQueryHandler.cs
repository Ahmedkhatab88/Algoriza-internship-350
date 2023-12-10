

using ApplicationLayer.Exceptions;
using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.admins.Queries.GetAdminsList
{
    public class GetAdminListQueryHandler : IRequestHandler<GetAdminListQuery, List<AdminViewModel>>
    {
        private readonly IGenericRepository<Admin> _repository;
        private readonly IMapper _mapper;

        public GetAdminListQueryHandler(IGenericRepository<Admin> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<AdminViewModel>> Handle(GetAdminListQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.GetAll();

            if(query == null)
            {
                throw new ItemNotFoundException("not exist admins");
            }

            var map = _mapper.Map<List<AdminViewModel>>(query);

            return map;
        }
    }
}
