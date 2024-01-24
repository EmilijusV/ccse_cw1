using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ccse_cw1.Data;
using ccse_cw1.Models;
using Microsoft.AspNetCore.Authorization;

namespace ccse_cw1.Pages.TempSolution
{
    [Authorize(Roles = "admin, seller")]
    public class CreateHotelModel : PageModel
    {
        private readonly ccse_cw1.Data.BookingSystem _context;

        public CreateHotelModel(ccse_cw1.Data.BookingSystem context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["HotelID"] = new SelectList(_context.Hotels, "HotelID", "HotelID");
            return Page();
        }

        [BindProperty]
        public HotelBooking HotelBooking { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.HotelBookings == null || HotelBooking == null)
            {
                return Page();
            }

            _context.HotelBookings.Add(HotelBooking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
