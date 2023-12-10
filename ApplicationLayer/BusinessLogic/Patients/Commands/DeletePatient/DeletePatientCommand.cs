

using MediatR;

namespace ApplicationLayer.BusinessLogic.Patients.Commands.DeletePatient
{
    public class DeletePatientCommand : IRequest<bool>
    {
        public int id { get; set; }
    }
}
