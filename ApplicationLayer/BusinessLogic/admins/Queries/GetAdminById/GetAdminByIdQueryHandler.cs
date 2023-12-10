
using ApplicationLayer.Exceptions;
using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.admins.Queries.GetAdminById
{
    public class GetAdminByIdQueryHandler : IRequestHandler<GetAdminByIdQuery, AdminDetailViewModel>
    {
        private readonly IGenericRepository<Admin> _repository;
        private readonly IMapper _mapper;

        public GetAdminByIdQueryHandler(IGenericRepository<Admin> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AdminDetailViewModel> Handle(GetAdminByIdQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.GetById(request.Id);

            if (query is null) 
            { 
               throw new ItemNotFoundException("Item is not Exist");
            }

            var map = _mapper.Map<AdminDetailViewModel>(query);

            return map;
        }


    }
}
