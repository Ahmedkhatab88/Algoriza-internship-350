

using ApplicationLayer.BusinessLogic.admins.Queries.GetTopFiveSpecializations;
using ApplicationLayer.BusinessLogic.admins.Queries.GetTopTenDoctors;
using ApplicationLayer.GenericInterface;
using DomainLayer.Entities;

namespace ApplicationLayer.NonGenericInterface
{
    public interface IAdminRepository : IGenericRepository<Admin>
    {
        Task<int> NumOfDoctors();
        Task<int> NumOfPatients();
        Task<List<GetTopDoctorsViewModel>> GetTopTenDoctors();
        Task<int> NumberOfRequests();
        Task<int> NumberOfRequestsLastDay();
        Task<List<SpecializationViewModel>> GetTopFiveSpecializations();



    }

}
