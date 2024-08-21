using Microsoft.EntityFrameworkCore;
using Domain.Entities;
namespace Infrastructure.Foundation;

public class TheatreDbContext : DbContext
{
    public TheatreDbContext( DbContextOptions<TheatreDbContext> options )
        : base( options )
    { }

    #region DbSets

    public DbSet<Theatre> Theatres { get; set; }
    public DbSet<Play> Plays { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Composition> Compositions { get; set; }
    public DbSet<Hours> Hours { get; set; }

    #endregion

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        base.OnModelCreating( modelBuilder );

        modelBuilder.ApplyConfigurationsFromAssembly( GetType().Assembly );
    }
}
