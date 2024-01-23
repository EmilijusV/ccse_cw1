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

namespace ccse_cw1.Pages.TempSolution
{
    [Authorize(Roles = "admin, seller")]
    public class IndexModel : PageModel
    {
        private readonly ccse_cw1.Data.BookingSystem _context;

        public IndexModel(ccse_cw1.Data.BookingSystem context)
        {
            _context = context;
        }

        public IList<TourBooking> TourBooking { get; set; } = default!;
        public IList<HotelBooking> HotelBooking { get; set; } = default!;
        public IList<Package> Package { get; set; } = default!;

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
        }
    }
}
