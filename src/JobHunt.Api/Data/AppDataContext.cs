using Microsoft.EntityFrameworkCore;

namespace JobHunt.Api.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options)
            : base(options)
        {
        }

        public DbSet<Models.JobApplication> JobApplications { get; set; } = null!;
        
    }
}