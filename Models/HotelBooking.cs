using System.Reflection.Metadata;

namespace ccse_cw1.Models
{
    public class HotelBooking
    {
        public int HotelBookingID {  get; set; }

        public int HotelID { get; set; }

        public string CustomerID { get; set; } = "";

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double TotalPrice { get; set; }

        public Hotel Hotel { get; set; } = null!;
    }
}
