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
    public class DeleteHotelModel : PageModel
    {
        private readonly ccse_cw1.Data.BookingSystem _context;

        public DeleteHotelModel(ccse_cw1.Data.BookingSystem context)
        {
            _context = context;
        }

        [BindProperty]
      public HotelBooking HotelBooking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.HotelBookings == null)
            {
                return NotFound();
            }

            var hotelbooking = await _context.HotelBookings.FirstOrDefaultAsync(m => m.HotelBookingID == id);

            if (hotelbooking == null)
            {
                return NotFound();
            }
            else 
            {
                HotelBooking = hotelbooking;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.HotelBookings == null)
            {
                return NotFound();
            }
            var hotelbooking = await _context.HotelBookings.FindAsync(id);

            if (hotelbooking != null)
            {
                HotelBooking = hotelbooking;
                _context.HotelBookings.Remove(HotelBooking);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
