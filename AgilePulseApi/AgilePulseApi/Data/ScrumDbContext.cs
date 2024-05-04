using Microsoft.EntityFrameworkCore;

namespace AgilePulseApi.Data
{
    public class ScrumDbContext:DbContext
    {
        public ScrumDbContext(DbContextOptions<ScrumDbContext> options):base(options)
        {
            
        }
    }
}
