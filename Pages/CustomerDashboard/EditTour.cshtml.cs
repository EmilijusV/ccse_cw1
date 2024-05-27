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
    public class EditTourModel : PageModel
    {
        private readonly ccse_cw1.Data.BookingSystem _context;

        public EditTourModel(ccse_cw1.Data.BookingSystem context)
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

            var tourbooking =  await _context.TourBookings.FirstOrDefaultAsync(m => m.TourBookingID == id);
            if (tourbooking == null)
            {
                return NotFound();
            }
            TourBooking = tourbooking;
           ViewData["TourID"] = new SelectList(_context.Tours, "TourID", "TourID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            _context.Attach(TourBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourBookingExists(TourBooking.TourBookingID))
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

        private bool TourBookingExists(int id)
        {
          return (_context.TourBookings?.Any(e => e.TourBookingID == id)).GetValueOrDefault();
        }
    }
}
