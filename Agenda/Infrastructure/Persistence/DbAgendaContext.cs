using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class DbAgendaContext: DbContext
{
    public DbAgendaContext(DbContextOptions<DbAgendaContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}