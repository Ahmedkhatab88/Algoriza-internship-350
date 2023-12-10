using MediatR;

namespace ApplicationLayer.BusinessLogic.Patients.Commands.CancelBook
{
    public class CancelBookCommand : IRequest<bool>
    {
        public int BookId { get; set; }
    }
}
