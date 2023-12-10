

using ApplicationLayer.Exceptions;
using ApplicationLayer.NonGenericInterface;
using MediatR;

namespace ApplicationLayer.BusinessLogic.admins.Queries.GetTopFiveSpecializations
{
    public class TopFiveSpecializationsQueryHandler : IRequestHandler<TopFiveSpecializationsQuery, List<SpecializationViewModel>>
    {
        private readonly IAdminRepository _repository;

        public TopFiveSpecializationsQueryHandler(IAdminRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SpecializationViewModel>> Handle(TopFiveSpecializationsQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.GetTopFiveSpecializations();

            if (query == null)
            {
                throw new ItemNotFoundException("not exist specializations");
            }

            return query;
        }
    }
}
