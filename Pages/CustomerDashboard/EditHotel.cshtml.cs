using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ccse_cw1.Data;
using ccse_cw1.Models;
using Microsoft.AspNetCore.Authorization;

namespace ccse_cw1.Pages.CustomerDashboard
{
    [Authorize(Roles = "client")]
    public class EditHotelModel : PageModel
    {
        private readonly ccse_cw1.Data.BookingSystem _context;

        public EditHotelModel(ccse_cw1.Data.BookingSystem context)
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
            HotelBooking = hotelbooking;
            ViewData["HotelID"] = new SelectList(_context.Hotels, "HotelID", "HotelID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            _context.Attach(HotelBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelBookingExists(HotelBooking.HotelBookingID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool HotelBookingExists(int id)
        {
            return (_context.HotelBookings?.Any(e => e.HotelBookingID == id)).GetValueOrDefault();
        }
    }
}
