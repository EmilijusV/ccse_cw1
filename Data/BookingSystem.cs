using ccse_cw1.Models;
using ccse_cw1.Services;
using Microsoft.EntityFrameworkCore;

namespace ccse_cw1.Data
{
    public class BookingSystem : DbContext
    {
        public BookingSystem(DbContextOptions<BookingSystem> options) : base(options) 
        {
        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelBooking> HotelBookings { get; set; }
        public DbSet<HotelDate> HotelDates { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourBooking> TourBookings { get; set; }
        public DbSet<TourDate> TourDates { get; set; }
        public DbSet<Package> Packages { get; set; }
    }
}
