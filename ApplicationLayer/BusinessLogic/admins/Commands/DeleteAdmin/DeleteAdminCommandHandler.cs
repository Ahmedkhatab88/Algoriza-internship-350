

using ApplicationLayer.Exceptions;
using ApplicationLayer.GenericInterface;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.admins.Commands.DeleteAdmin
{
    public class DeleteAdminCommandHandler : IRequestHandler<DeleteAdminCommand, bool>
    {
        private readonly IGenericRepository<Admin> _repository;

        public DeleteAdminCommandHandler(IGenericRepository<Admin> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
        {
            var command = await _repository.GetById(request.Id);

            if(command == null) 
            {
                throw new ItemNotFoundException("this admin is not exist");
            }

            await _repository.Delete(command);

            return true;
        }
    }
}
