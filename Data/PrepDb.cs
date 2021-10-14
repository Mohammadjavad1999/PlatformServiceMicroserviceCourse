using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void prepPopulationDb(IApplicationBuilder app)
        {
            using (var ServiceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(ServiceScope.ServiceProvider.GetService<Data.DataBaseContext>());

            }
        }
        public static void SeedData(DataBaseContext context)
        {
            if (!context.Platforms.Any())
            {
                System.Console.WriteLine("--> Seeding Data...");
                context.Platforms.AddRange(
                    new Models.Platform() {  Name =  "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                    new Models.Platform() {  Name = "Sql Server Express", Publisher = "Microsoft", Cost = "Free" },
                    new Models.Platform() {  Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" });
                context.SaveChanges();

            }
            else
            {
                System.Console.WriteLine("No Data For Seeding");
            }
        }
    }
}