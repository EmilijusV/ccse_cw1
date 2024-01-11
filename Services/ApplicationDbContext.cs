using Microsoft.EntityFrameworkCore;

namespace ccse_cw1.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
