using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class DbAgendaContext: DbContext
{
    public DbAgendaContext(DbContextOptions<DbAgendaContext> options) : base(options)
    {
    }
    // Types
    public DbSet<Domain.Entities.Type> Types { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}