using ccse_cw1.Data;
using ccse_cw1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ccse_cw1.Pages.ManagingDashboard
{ 
    [Authorize(Roles = "admin, seller")]
    public class ReportModel : PageModel
    {
        private readonly ccse_cw1.Data.BookingSystem _context;

        public ReportModel(ccse_cw1.Data.BookingSystem context)
        {
            _context = context;
        }

        public IList<HotelBooking> HotelBookings { get; set; } = default!;
        public IList<Hotel> Hotels { get; set; } = default!;
        public IList<HotelDate> HotelDates { get; set; } = default!;

        public IList<TourBooking> TourBookings { get; set; } = default!;
        public IList<TourDate> TourDates { get; set; }
        public IList<Tour> Tours { get; set; }
        public IList<Package> Packages { get; set; }
        public async Task OnGetAsync()
        {
            Tours = await _context.Tours.ToListAsync();
            TourDates = await _context.TourDates.ToListAsync();
            TourBookings = await _context.TourBookings.ToListAsync();
            HotelBookings = await _context.HotelBookings.ToListAsync();
            Hotels = await _context.Hotels.ToListAsync();
            HotelDates = await _context.HotelDates.ToListAsync();
            Packages = await _context.Packages.ToListAsync();
        }
    }
}
