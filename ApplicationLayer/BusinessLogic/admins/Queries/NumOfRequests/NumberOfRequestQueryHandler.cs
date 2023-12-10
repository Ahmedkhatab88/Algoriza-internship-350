
using ApplicationLayer.Exceptions;
using ApplicationLayer.NonGenericInterface;
using MediatR;

namespace ApplicationLayer.BusinessLogic.admins.Queries.NumOfRequests
{
    public class NumberOfRequestQueryHandler : IRequestHandler<NumberOfRequestQuery,int>
    {
        private readonly IAdminRepository _repository;

        public NumberOfRequestQueryHandler(IAdminRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(NumberOfRequestQuery request, CancellationToken cancellationToken)
        {
            var count = await _repository.NumberOfRequests();

            if(count == 0)
            {
                throw new ItemNotFoundException("Not found requests");
            }

            return count;
        }
    }
}
