

using ApplicationLayer.Exceptions;
using ApplicationLayer.GenericInterface;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Settings.Commands.DeleteSetting
{
    public class DeleteSettingCommandHandler : IRequestHandler<DeleteSettingCommand, bool>
    {
        private readonly IGenericRepository<Setting> _repository;

        public DeleteSettingCommandHandler(IGenericRepository<Setting> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteSettingCommand request, CancellationToken cancellationToken)
        {

            var query = await _repository.GetById(request.Id);

            if (query == null)
            {
                throw new ItemNotFoundException("this Setting is not exist");
            }

            await _repository.Delete(query);

            return true;
        }
    }

}
