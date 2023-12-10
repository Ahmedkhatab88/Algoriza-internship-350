

using ApplicationLayer.Exceptions;
using ApplicationLayer.NonGenericInterface;
using MediatR;

namespace ApplicationLayer.BusinessLogic.admins.Queries.GetNumberOfDoctors
{
    public class GetNumberOfDoctorsQueryHandler : IRequestHandler<GetNumberOfDoctorsQuery, int>
    {
        private readonly IAdminRepository _repository;

        public GetNumberOfDoctorsQueryHandler(IAdminRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(GetNumberOfDoctorsQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.NumOfDoctors();

            if(query == 0)
            {
                throw new ItemNotFoundException("don't exist doctors");
            }

            return query;
        }
    }

}
