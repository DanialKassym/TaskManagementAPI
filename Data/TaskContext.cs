using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Data;


public class TaskContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public TaskContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public DbSet<MyTasks> tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
                .UseSnakeCaseNamingConvention();
        }
    }
}