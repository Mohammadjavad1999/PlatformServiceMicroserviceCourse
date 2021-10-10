using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> opt):base(opt)
        {
            
        }
        public DbSet<Platform> Platforms    { get; set; }
    }
}