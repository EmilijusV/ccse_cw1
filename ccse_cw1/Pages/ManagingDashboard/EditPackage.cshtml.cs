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

namespace ccse_cw1.Pages.ManagingDashboard
{
    [Authorize(Roles = "admin, seller")]
    public class EditPackageModel : PageModel
    {
        private readonly BookingSystem _context;

        public EditPackageModel(BookingSystem context)
        {
            _context = context;
        }

        [BindProperty]
        public Package Package { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Packages == null)
            {
                return NotFound();
            }

            var package = await _context.Packages.FirstOrDefaultAsync(m => m.PackageID == id);
            if (package == null)
            {
                return NotFound();
            }
            Package = package;
            ViewData["HotelID"] = new SelectList(_context.Hotels, "HotelID", "HotelID");
            ViewData["TourID"] = new SelectList(_context.Tours, "TourID", "TourID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            _context.Attach(Package).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackageExists(Package.PackageID))
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

        private bool PackageExists(int id)
        {
            return (_context.Packages?.Any(e => e.PackageID == id)).GetValueOrDefault();
        }
    }
}
