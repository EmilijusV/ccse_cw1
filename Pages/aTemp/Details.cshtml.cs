using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ccse_cw1.Data;
using ccse_cw1.Models;

namespace ccse_cw1.Pages.aTemp
{
    public class DetailsModel : PageModel
    {
        private readonly ccse_cw1.Data.BookingSystem _context;

        public DetailsModel(ccse_cw1.Data.BookingSystem context)
        {
            _context = context;
        }

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
            else 
            {
                Package = package;
            }
            return Page();
        }
    }
}
