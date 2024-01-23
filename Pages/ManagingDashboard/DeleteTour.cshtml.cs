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

namespace ccse_cw1.Pages.ManagingDashboard
{
    [Authorize(Roles = "admin, seller")]
    public class DeleteTourModel : PageModel
    {
        private readonly ccse_cw1.Data.BookingSystem _context;

        public DeleteTourModel(ccse_cw1.Data.BookingSystem context)
        {
            _context = context;
        }

        [BindProperty]
      public TourBooking TourBooking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TourBookings == null)
            {
                return NotFound();
            }

            var tourbooking = await _context.TourBookings.FirstOrDefaultAsync(m => m.TourBookingID == id);

            if (tourbooking == null)
            {
                return NotFound();
            }
            else 
            {
                TourBooking = tourbooking;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TourBookings == null)
            {
                return NotFound();
            }
            var tourbooking = await _context.TourBookings.FindAsync(id);

            if (tourbooking != null)
            {
                TourBooking = tourbooking;
                _context.TourBookings.Remove(TourBooking);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
