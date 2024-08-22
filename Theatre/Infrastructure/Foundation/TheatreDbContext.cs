using Microsoft.EntityFrameworkCore;
using Domain.Entities;
namespace Infrastructure.Foundation;

public class TheatreDbContext : DbContext
{
    public TheatreDbContext( DbContextOptions<TheatreDbContext> options )
        : base( options )
    { }

    //Sets
    protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
    {
        base.OnConfiguring( optionsBuilder );
        optionsBuilder.UseSqlServer( "Server=localhost\\SQLExpress;Database=Theatre;TrustedConnection=True;TrustedServerSertificate=True;" );
    }

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        base.OnModelCreating( modelBuilder );

        modelBuilder.ApplyConfigurationsFromAssembly( GetType().Assembly );
    }
}
