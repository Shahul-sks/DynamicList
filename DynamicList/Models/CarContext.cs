using Microsoft.EntityFrameworkCore;

namespace DynamicList.Models
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }

    }
}
