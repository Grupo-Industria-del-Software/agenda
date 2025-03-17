using Domain.AggregateRoots.Activities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Activity = Domain.AggregateRoots.Activities.Activity;
using Task = Domain.AggregateRoots.Activities.Task;

namespace Infrastructure.Persistence;

public class DbAgendaContext : DbContext
{
    public DbAgendaContext(DbContextOptions<DbAgendaContext> options) : base(options)
    {
    }
    public DbSet<Domain.Entities.Type> Types { get; set; }

    public DbSet<User> Users { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Task> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
    }
}