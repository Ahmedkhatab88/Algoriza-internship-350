namespace ApplicationLayer.BusinessLogic.admins.Queries.GetTopTenDoctors
{
    public class GetTopDoctorsViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Specialize { get; set; } = null!;
        public byte[]? Image { get; set; }
        public int Requests { get; set; }
    }
}
