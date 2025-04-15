using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Context
{
    public class PracticePackDbContextFactory : IDesignTimeDbContextFactory<PracticePackDbContext>
    {
        public PracticePackDbContext CreateDbContext(string[] args)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "Configurations");

            Console.WriteLine("Loading config from: " + basePath);

            var config = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            Console.WriteLine("ConnectionString: " + connectionString);

            var optionsBuilder = new DbContextOptionsBuilder<PracticePackDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new PracticePackDbContext(optionsBuilder.Options, new HttpContextAccessor());
        }
    }
}
