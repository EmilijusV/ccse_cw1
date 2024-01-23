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
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? SearchDate { get; set; }

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

            if (!string.IsNullOrEmpty(SearchTerm) && SearchDate.HasValue)
            {
                // Perform search using the database context
                var searchResults = _context.Tours
                    .Where(h => h.TourName.Contains(SearchTerm) &&
                                _context.TourDates.Any(a => a.TourID == h.TourID &&
                                                                  a.AvailableFrom.Date <= SearchDate.Value.Date &&
                                                                  a.AvailableTo.Date >= SearchDate.Value.Date))
                    .ToList();

                ViewData["SearchResults"] = searchResults;
            }
            else if (!string.IsNullOrEmpty(SearchTerm))
            {
                // Perform search only based on the search term
                var searchResults = _context.Tours
                    .Where(h => h.TourName.Contains(SearchTerm))
                    .ToList();

                ViewData["SearchResults"] = searchResults;
            }
            else if (SearchDate.HasValue)
            {
                // Perform search only based on the date
                var searchResults = _context.Tours
                    .Where(h => _context.TourDates.Any(a => a.TourID == h.TourID &&
                                                                  a.AvailableFrom.Date <= SearchDate.Value.Date &&
                                                                  a.AvailableTo.Date >= SearchDate.Value.Date))
                    .ToList();

                ViewData["SearchResults"] = searchResults;
            }
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

