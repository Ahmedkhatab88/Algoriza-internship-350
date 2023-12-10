

using MediatR;

namespace ApplicationLayer.BusinessLogic.Bills.Queries.GetBillsById
{
    public class GetBookingQuery : IRequest<BookingDetailViewModel>
    {
        public int id { get; set; }

    }
}
