using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ccse_cw1.Data;
using ccse_cw1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ccse_cw1.Services;
using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace ccse_cw1.Pages
{
    [BindProperties]
    public class BookingModel : PageModel
    {
        private readonly BookingSystem _context;

       // private readonly UserManager<ApplicationUser> _userManager; // user id

        public BookingModel(BookingSystem context)
        {
            _context = context;
        }
        /*public BookingModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }*/
        public IList<Hotel> BookingSystems { get; set; }
        public IList<HotelDate> HotelDates { get; set; }

        public HotelBooking HotelBooking { get; set; }

        public double TotalPrice { get; set; }

        /*        public async Task<string> GetUserIdAsync()
                {
                    ApplicationUser user = await _userManager.GetUserAsync(User);

                    if (user != null)
                    {
                        return user.Id;
                    }
                    return null;
                }*/
        public async Task OnGetAsync()
        {
            BookingSystems = await _context.Hotels.ToListAsync();
            HotelDates = await _context.HotelDates.ToListAsync();
        }

        public async Task<IActionResult> OnPost(HotelBooking hotelBooking)
        {

            await _context.HotelBookings.AddAsync(hotelBooking);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }

    }
}
