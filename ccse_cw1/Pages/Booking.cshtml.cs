using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ccse_cw1.Data;
using ccse_cw1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ccse_cw1.Services;
using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace ccse_cw1.Pages
{
    [Authorize]
    [BindProperties]
    public class BookingModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? SearchDate { get; set; }

        private readonly BookingSystem _context;

        private readonly UserManager<ApplicationUser> _userManager; // user id

        public BookingModel(BookingSystem context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Hotel> BookingSystems { get; set; }
        public IList<HotelDate> HotelDates { get; set; }

        public HotelBooking HotelBooking { get; set; }

        public double TotalPrice { get; set; }

        public async Task OnGetAsync()
        {
            BookingSystems = await _context.Hotels.ToListAsync();
            HotelDates = await _context.HotelDates.ToListAsync();

            if (!string.IsNullOrEmpty(SearchTerm) && SearchDate.HasValue)
            {
                // Perform search using the database context
                var searchResults = _context.Hotels
                    .Where(h => h.HotelName.Contains(SearchTerm) &&
                                _context.HotelDates.Any(a => a.HotelID == h.HotelID &&
                                                                  a.AvailableFrom.Date <= SearchDate.Value.Date &&
                                                                  a.AvailableTo.Date >= SearchDate.Value.Date))
                    .ToList();

                ViewData["SearchResults"] = searchResults;
            }
            else if (!string.IsNullOrEmpty(SearchTerm))
            {
                // Perform search only based on the search term
                var searchResults = _context.Hotels
                    .Where(h => h.HotelName.Contains(SearchTerm))
                    .ToList();

                ViewData["SearchResults"] = searchResults;
            }
            else if (SearchDate.HasValue)
            {
                // Perform search only based on the date
                var searchResults = _context.Hotels
                    .Where(h => _context.HotelDates.Any(a => a.HotelID == h.HotelID &&
                                                                  a.AvailableFrom.Date <= SearchDate.Value.Date &&
                                                                  a.AvailableTo.Date >= SearchDate.Value.Date))
                    .ToList();

                ViewData["SearchResults"] = searchResults;
            }
        }

        public async Task<IActionResult> OnPost(HotelBooking hotelBooking)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                hotelBooking.CustomerID = user.Id;
            }
            else
            {
                return RedirectToPage("Error");
            }
            await _context.HotelBookings.AddAsync(hotelBooking);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}


 
