

using ApplicationLayer.GenericInterface;
using DomainLayer.Entities;

namespace ApplicationLayer.NonGenericInterface
{
    public interface IDoctorRepository : IGenericRepository<Doctor>
    {
        Task<bool> ConfirmCheckUp(int BookId);
    }

}
