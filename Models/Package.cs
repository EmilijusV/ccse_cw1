namespace ccse_cw1.Models
{
    public class Package
    {
        public int PackageID {  get; set; }

        public int TourID { get; set; }
        public int HotelID { get; set; }
        public string CustomerID { get; set; } = "";

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TotalCost { get; set; }
    }
}
