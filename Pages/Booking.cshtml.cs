using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ccse_cw1.Data;
using ccse_cw1.Models;
using Microsoft.EntityFrameworkCore;

namespace ccse_cw1.Pages
{
    public class BookingModel : PageModel
    {
        private readonly BookingSystem _context;

        public BookingModel(BookingSystem context)
        {
            _context = context;
        }

        public IList<Hotel> BookingSystems { get; set; }
        public IList<HotelDate> HotelDates { get; set; }

        public async Task OnGetAsync()
        {
            BookingSystems = await _context.Hotels.ToListAsync();
            HotelDates = await _context.HotelDates.ToListAsync();
        }
    }
}
