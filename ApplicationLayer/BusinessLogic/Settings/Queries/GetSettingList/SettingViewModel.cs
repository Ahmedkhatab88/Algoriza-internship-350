

using ApplicationLayer.BusinessLogic.Bookings.Queries.GetBookingsList;

namespace ApplicationLayer.BusinessLogic.Settings.Queries.GetSettingList
{
    public class SettingViewModel
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int DoctorId { get; set; }
        public DoctorDTO Doctor { get; set; } = null!;
        public TimeSlotDTO TimeSlot { get; set; } = null!;
    }
}
