
using MediatR;

namespace ApplicationLayer.BusinessLogic.Patients.Queries.GetAllBookings
{
    public class GetBookingQuery : IRequest<List<GetBookingViewModel>>
    {
        public int PatientId { get; set; }
    }
}
