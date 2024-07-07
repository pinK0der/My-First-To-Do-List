using Microsoft.EntityFrameworkCore;
using To_Do_List.Models;

namespace To_Do_List.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Event> eventstodo { get; set; }
    }
}
