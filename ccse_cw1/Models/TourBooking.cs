namespace ccse_cw1.Models
{
    public class TourBooking
    {
        public int TourBookingID {  get; set; }
        public int TourID { get; set; }
        public string CustomerID { get; set; } = "";
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TotalCost { get; set; }

        public Tour Tour { get; set; } = null!;
    }
}
