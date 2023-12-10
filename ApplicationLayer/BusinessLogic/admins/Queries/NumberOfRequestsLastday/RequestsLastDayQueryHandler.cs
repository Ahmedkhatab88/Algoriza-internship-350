using ApplicationLayer.Exceptions;
using ApplicationLayer.NonGenericInterface;
using MediatR;

namespace ApplicationLayer.BusinessLogic.admins.Queries.NumberOfRequestsLastday
{
    public class RequestsLastDayQueryHandler : IRequestHandler<RequestsLastDayQuery, int>
    {
        private readonly IAdminRepository _adminRepository;

        public RequestsLastDayQueryHandler(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<int> Handle(RequestsLastDayQuery request, CancellationToken cancellationToken)
        {
            var count = await _adminRepository.NumberOfRequestsLastDay();

            if (count == 0)
            {
                throw new ItemNotFoundException("don't exist requests at last day");
            }

            return count;
        }
    }
}
