using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class DbAgendaContext: DbContext
{
    public DbAgendaContext(DbContextOptions<DbAgendaContext> options) : base(options)
    {
    }
    public DbSet<Domain.Entities.Type> Types { get; set; }
    
    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
    }
}