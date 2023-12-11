using Microsoft.EntityFrameworkCore;

namespace WeatherApp.Models
{
    public class WeatherDataContext : DbContext
    {

        public WeatherDataContext(DbContextOptions<WeatherDataContext> options) : base(options)
        {
        }

        public DbSet<UsersModel> Users { get; set; }
        public DbSet<LocationsModel> Locations { get; set; }    
        public DbSet<SessionsModel> Sessions { get; set; }
    }
}
