using MediatR;

namespace ApplicationLayer.BusinessLogic.Bills.Queries.GetBillsList
{
    public class GetBookingListQuery : IRequest<List<BookingViewModel>>
    {

    }
}
