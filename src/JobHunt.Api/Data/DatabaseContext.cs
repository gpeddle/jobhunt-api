using Microsoft.EntityFrameworkCore;

namespace JobHunt.Api.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Models.JobApplication> JobApplications { get; set; } = null!;
    }
}