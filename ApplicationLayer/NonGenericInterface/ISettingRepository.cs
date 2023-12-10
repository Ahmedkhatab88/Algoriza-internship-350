

using ApplicationLayer.GenericInterface;
using DomainLayer.Entities;

namespace ApplicationLayer.NonGenericInterface
{
    public interface ISettingRepository : IGenericRepository<Setting>
    {
        Task<bool> Deactivate(int id);
    }

}
