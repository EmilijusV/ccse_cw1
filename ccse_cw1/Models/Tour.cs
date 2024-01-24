using Microsoft.Extensions.Hosting;

namespace ccse_cw1.Models
{
    public class Tour
    {
        public int TourID { get; set; }

        public string TourName { get; set; } = "";

        public int Duration { get; set; }

        public double Price { get; set; }

        public int NumSpaces { get; set; }

        public ICollection<TourBooking> TourBookings { get; } = new List<TourBooking>();
        public ICollection<Package> Packages { get; } = new List<Package>();
    }
}
