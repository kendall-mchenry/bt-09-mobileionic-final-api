using final_task_api.Models;
using Microsoft.EntityFrameworkCore;
using Task = final_task_api.Models.Task;

namespace final_task_api.Migrations;

public class TasksDbContext : DbContext 
{
    public DbSet<Task> Tasks { get; set; }

    public TasksDbContext(DbContextOptions<TasksDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Task>(entity => 
        {
            entity.HasKey(e => e.TaskId);
            
            entity.Property(e => e.TaskTitle).IsRequired();
            entity.Property(e => e.TaskCompleted).IsRequired().HasDefaultValue(false);
        });
    }
}