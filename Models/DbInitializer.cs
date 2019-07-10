using DataCollectionAPI;
using DataCollectionAPI.Models;
using System.Linq;
namespace DataCollectionAPI
{
    public static class DbInitializer
    {
        public static void Initialize(EventContext context)
        {
            
            context.Database.EnsureCreated();
            
        }
    }
}