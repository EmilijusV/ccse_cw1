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
    public class IndexModel : PageModel
    {
        private readonly ccse_cw1.Data.BookingSystem _context;

        public IndexModel(ccse_cw1.Data.BookingSystem context)
        {
            _context = context;
        }

        public IList<Package> Package { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Packages != null)
            {
                Package = await _context.Packages
                .Include(p => p.Hotel)
                .Include(p => p.Tour).ToListAsync();
            }
        }
    }
}
