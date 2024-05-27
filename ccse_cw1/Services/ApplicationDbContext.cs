using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ccse_cw1.Models;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace ccse_cw1.Services
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

                var admin = new IdentityRole("admin");
                admin.NormalizedName = "admin";

                var client = new IdentityRole("client");
                client.NormalizedName = "client";

                var seller = new IdentityRole("seller");
                seller.NormalizedName = "seller";

                builder.Entity<IdentityRole>().HasData(admin, client, seller);

        
        }
    }
}
