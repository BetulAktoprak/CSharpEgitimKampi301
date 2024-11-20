namespace CSharpEgitimKampi301.EFProject.Entities
{
    public sealed class Location
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public byte Capacity { get; set; }
        public decimal Price { get; set; }
        public string DayNight { get; set; }
        public int GuideId { get; set; }
        public Guide Guide { get; set; }
    }
}
