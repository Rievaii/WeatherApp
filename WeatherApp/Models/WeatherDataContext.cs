using Microsoft.EntityFrameworkCore;

namespace WeatherApp.Models
{
    public class WeatherDataContext : DbContext
    {

        public WeatherDataContext(DbContextOptions<WeatherDataContext> options) : base(options)
        {
        }

        // DbSet<TEntity> для каждой сущности в вашей базе данных
        public DbSet<UsersModel> Users { get; set; }

        
    }
}
