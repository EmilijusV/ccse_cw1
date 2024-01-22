namespace ccse_cw1.Models
{
    public class Package
    {
        public int PackageID {  get; set; }

        public int TourID { get; set; }
        public int HotelID { get; set; }
        public string CustomerID { get; set; } = "";
        public DateTime HotelStartDate { get; set; }
        public DateTime HotelEndDate { get; set; }
        public DateTime TourStartDate { get; set; }
        public DateTime TourEndDate { get; set; }
        public double TotalCost { get; set; }


        public Hotel Hotel { get; set; } = null!;
        public Tour Tour { get; set; } = null!;
    }
}
