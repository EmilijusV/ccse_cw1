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

    public class PackageBookingModel : PageModel
    {
        private readonly BookingSystem _context;

        private readonly UserManager<ApplicationUser> _userManager; // user id

        public PackageBookingModel(BookingSystem context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Hotel> BookingSystems { get; set; }
        public IList<HotelDate> HotelDates { get; set; }
        public IList<Tour> Tours { get; set; }
        public IList<TourDate> TourDates { get; set; }

        public double TotalCost { get; set; }
        public double TotalPrice { get; set; }

        public Package Package { get; set; }

        public async Task OnGetAsync()
        {
            BookingSystems = await _context.Hotels.ToListAsync();
            HotelDates = await _context.HotelDates.ToListAsync();
            Tours = await _context.Tours.ToListAsync();
            TourDates = await _context.TourDates.ToListAsync();

        }

        public async Task<IActionResult> OnPost(Package package)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                package.CustomerID = user.Id;
            }
            else
            {
                return RedirectToPage("Error");
            }
            await _context.Packages.AddAsync(package);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
