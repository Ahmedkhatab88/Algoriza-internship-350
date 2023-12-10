using ApplicationLayer.BusinessLogic.Settings.Queries.GetSettingList;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Settings.Commands.AddSetting
{
    public class AddSettingCommand : IRequest<int>
    {
        public decimal Price { get; set; }
        public int DoctorId { get; set; }
        public TimeSlotDTO TimeSlot { get; set; } = null!;
    }
}
