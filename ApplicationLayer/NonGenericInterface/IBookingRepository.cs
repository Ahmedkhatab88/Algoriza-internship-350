

using ApplicationLayer.GenericInterface;
using DomainLayer.Entities;

namespace ApplicationLayer.NonGenericInterface
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
    }

}
