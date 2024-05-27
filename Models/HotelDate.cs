namespace ccse_cw1.Models
{
    public class HotelDate
    {
        public int HotelDateID { get; set; }

        public int HotelID { get; set; }

        public DateTime AvailableFrom { get; set; }

        public DateTime AvailableTo { get; set; }

        public Hotel Hotel { get; set; } = null!;
    }
}
