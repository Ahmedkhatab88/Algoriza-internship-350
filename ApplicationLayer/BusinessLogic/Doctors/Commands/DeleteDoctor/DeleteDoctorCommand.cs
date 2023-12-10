

using MediatR;

namespace ApplicationLayer.BusinessLogic.Doctors.Commands.DeleteDoctor
{
    public class DeleteDoctorCommand : IRequest<bool>
    {
        public int id { get; set; }
    }
}
