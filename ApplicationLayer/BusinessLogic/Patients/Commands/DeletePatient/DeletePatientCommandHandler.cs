

using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Patients.Commands.DeletePatient
{
    public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand, bool>
    {
        private readonly IGenericRepository<Patient> _repository;

        public DeletePatientCommandHandler(IGenericRepository<Patient> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var query = await _repository.GetById(request.id);

            if (query == null)
            {
                throw new ArgumentException("this patient is not exist");
            }

            await _repository.Delete(query);
            
            return true;
        }
    }
}
