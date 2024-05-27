using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ccse_cw1.Data;
using ccse_cw1.Models;
using Microsoft.AspNetCore.Authorization;

namespace ccse_cw1.Pages.CustomerDashboard
{
    [Authorize(Roles = "client")]
    public class IndexModel : PageModel
    {
        private readonly ccse_cw1.Data.BookingSystem _context;

        public IndexModel(ccse_cw1.Data.BookingSystem context)
        {
            _context = context;
        }

        public IList<TourBooking> TourBooking { get;set; } = default!;
        public IList<HotelBooking> HotelBooking { get; set; } = default!;
        public IList<Package> Package { get; set; } = default!;

        public IList<TourBooking> TourBookingsLessThan14DaysLeft { get; set; } = default!;
        public IList<HotelBooking> HotelBookingsLessThan14DaysLeft { get; set; } = default!;
        public IList<Package> PackagesLessThan14DaysLeft { get; set; } = default!;



        public async Task OnGetAsync()
        {
            if (_context.TourBookings != null)
            {
                TourBooking = await _context.TourBookings
                .Include(t => t.Tour).ToListAsync();
            }
            if (_context.HotelBookings != null)
            {
                HotelBooking = await _context.HotelBookings
                .Include(h => h.Hotel).ToListAsync();
            }
            if (_context.Packages != null)
            {
                Package = await _context.Packages
                .Include(h => h.Hotel).ToListAsync();
            }

            if (_context.TourBookings != null)
            {
                TourBooking = await _context.TourBookings
                    .Include(t => t.Tour).ToListAsync();

                // Filter TourBookings less than 14 days left
                TourBookingsLessThan14DaysLeft = TourBooking
                    .Where(booking => (booking.StartDate - DateTime.Now).TotalDays < 14)
                    .ToList();
            }

            if (_context.HotelBookings != null)
            {
                HotelBooking = await _context.HotelBookings
                    .Include(h => h.Hotel).ToListAsync();

                // Filter HotelBookings less than 14 days left
                HotelBookingsLessThan14DaysLeft = HotelBooking
                    .Where(booking => (booking.StartDate - DateTime.Now).TotalDays < 14)
                    .ToList();
            }

            if (_context.Packages != null)
            {
                Package = await _context.Packages
                    .Include(h => h.Hotel).ToListAsync();

                // Filter Packages less than 14 days left
                PackagesLessThan14DaysLeft = Package
                    .Where(booking => (booking.HotelStartDate - DateTime.Now).TotalDays < 14)
                    .ToList();
            }
        }
    }
}
