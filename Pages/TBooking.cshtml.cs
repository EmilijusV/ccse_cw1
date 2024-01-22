using ccse_cw1.Data;
using ccse_cw1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ccse_cw1.Pages
{
    [Authorize]
    [BindProperties]

    public class TBookingModel : PageModel
    {
        private readonly BookingSystem _context;

        private readonly UserManager<ApplicationUser> _userManager; // user id

        public TBookingModel(BookingSystem context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Tour> BookingSystems { get; set; }
        public IList<TourDate> TourDates { get; set; }

        public TourBooking TourBooking { get; set; }

        public double TotalCost { get; set; }

        public async Task OnGetAsync()
        {
            BookingSystems = await _context.Tours.ToListAsync();
            TourDates = await _context.TourDates.ToListAsync();
        }

        public async Task<IActionResult> OnPost(TourBooking tourBooking)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                tourBooking.CustomerID = user.Id;
            }
            else
            {
                return RedirectToPage("Error");
            }
            await _context.TourBookings.AddAsync(tourBooking);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }

    }
}

