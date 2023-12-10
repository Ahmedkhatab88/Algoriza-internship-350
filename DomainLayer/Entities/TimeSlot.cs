namespace DomainLayer.Entities
{
    public class TimeSlot
    {
        public int Id { get; set; }
        public DateTime dateTime { get; set; } // DateTime will have Day and Time together
        public int SettingId { get; set; }
        public Setting Setting { get; set; } = null!;
    }

}
