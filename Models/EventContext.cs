using Microsoft.EntityFrameworkCore;
namespace DataCollectionAPI.Models
{
    public class EventContext : DbContext
    {
        public DbSet<Event> Events {get; set;}
        public DbSet<Login> Logins {get; set;}
        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {
        }
        
    }
}