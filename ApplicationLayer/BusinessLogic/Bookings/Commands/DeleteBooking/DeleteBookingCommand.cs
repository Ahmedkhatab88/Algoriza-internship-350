

using MediatR;

namespace ApplicationLayer.BusinessLogic.Bills.Commands.DeleteBill
{
    public class DeleteBookingCommand : IRequest<bool>
    {
        public int id { get; set; }
    }
}
