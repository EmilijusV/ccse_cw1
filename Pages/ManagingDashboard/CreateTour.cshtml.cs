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

namespace ccse_cw1.Pages.ManagingDashboard
{
    [Authorize(Roles = "admin, seller")]
    public class CreateTourModel : PageModel
    {
        private readonly ccse_cw1.Data.BookingSystem _context;

        public CreateTourModel(ccse_cw1.Data.BookingSystem context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["HotelID"] = new SelectList(_context.Hotels, "HotelID", "HotelID");
        ViewData["TourID"] = new SelectList(_context.Tours, "TourID", "TourID");
            return Page();
        }

        [BindProperty]
        public Package Package { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Packages == null || Package == null)
            {
                return Page();
            }

            _context.Packages.Add(Package);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
