using ApplicationLayer.BusinessLogic.Settings.Queries.GetSettingList;

namespace ApplicationLayer.BusinessLogic.Settings.Commands.UpdateSetting
{
    public class UpdateSettingRequest
    {
        public decimal Price { get; set; }
        public int DoctorId { get; set; }
        public TimeSlotDTO TimeSlot { get; set; } = null!;
    }
}
