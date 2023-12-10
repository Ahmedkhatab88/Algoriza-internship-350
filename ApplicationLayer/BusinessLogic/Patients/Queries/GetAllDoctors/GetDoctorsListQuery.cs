using MediatR;

namespace ApplicationLayer.BusinessLogic.Patients.Queries.GetAllDoctors
{
    public class GetDoctorsListQuery : IRequest<List<DoctorSearchViewModel>>
    {
        public int NumberPage { get; set; }
        public int SizePage { get; set; }
    }
}
