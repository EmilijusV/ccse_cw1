using System.ComponentModel.DataAnnotations;
using ccse_cw1.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;


namespace ccse_cw1.Models
{
    public class Hotel
    {
        [Key]
        public int HotelID { get; set; }

        public string HotelName { get; set; } = "";

        public string RoomType { get; set; } = "";

        public double Price { get; set; }
        public int NumRooms { get; set; }
        public ICollection<HotelBooking> HotelBookings { get; } = new List<HotelBooking>();
        public ICollection<HotelDate> HotelDates { get; } = new List<HotelDate>();
        public ICollection<Package> Packages { get; } = new List<Package>();

    }
}
