using ApplicationLayer.NonGenericInterface;
using MediatR;

namespace ApplicationLayer.BusinessLogic.admins.Queries.GetTopTenDoctors
{
    public class GetTopTenDoctorsQueryHandler : IRequestHandler<GetTopTenDoctorsQuery, List<GetTopDoctorsViewModel>>
    {
        private readonly IAdminRepository _adminRepository;

        public GetTopTenDoctorsQueryHandler(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<List<GetTopDoctorsViewModel>> Handle(GetTopTenDoctorsQuery request, CancellationToken cancellationToken)
        {
            var query = await _adminRepository.GetTopTenDoctors();

            if (query is null)
            {
                throw new Exception("don't exist doctors");
            }

            return query;
        }
    }
}
