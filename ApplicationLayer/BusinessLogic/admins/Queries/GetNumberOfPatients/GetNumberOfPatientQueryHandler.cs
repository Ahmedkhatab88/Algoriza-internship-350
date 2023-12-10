

using ApplicationLayer.Exceptions;
using ApplicationLayer.NonGenericInterface;
using MediatR;

namespace ApplicationLayer.BusinessLogic.admins.Queries.GetNumberOfPatients
{
    public class GetNumberOfPatientQueryHandler : IRequestHandler<GetNumberOfPatientQuery, int>
    {
        private readonly IAdminRepository _repository;

        public GetNumberOfPatientQueryHandler(IAdminRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(GetNumberOfPatientQuery request, CancellationToken cancellationToken)
        {

            var query = await _repository.NumOfDoctors();

            if (query == 0)
            {
                throw new ItemNotFoundException("don't exist Patients");
            }

            return query;
        }
    }
}
