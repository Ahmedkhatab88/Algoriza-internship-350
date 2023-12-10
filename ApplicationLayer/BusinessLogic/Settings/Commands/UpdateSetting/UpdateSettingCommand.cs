using ApplicationLayer.BusinessLogic.Settings.Queries.GetSettingList;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Settings.Commands.UpdateSetting
{
    public class UpdateSettingCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int DoctorId { get; set; }
        public TimeSlotDTO TimeSlot { get; set; } = null!;
    }
}
