using Microsoft.EntityFrameworkCore;
using ProjectManagement.Models;

namespace ProjectManagement.DbContexts;
public class ProjectManagementDbContext(DbContextOptions<ProjectManagementDbContext> options) : DbContext(options)
{  
    public DbSet<Status> Statuses { get; set; }
    public DbSet<ProjectTask> Tasks { get; set; }
    public DbSet<Project> Projects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuidler) 
    {
        modelBuidler.Entity<Project>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

        modelBuidler.Entity<ProjectTask>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();    
    }
}