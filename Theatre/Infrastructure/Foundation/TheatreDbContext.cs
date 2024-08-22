using Microsoft.EntityFrameworkCore;
using Domain.Entities;
namespace Infrastructure.Foundation;

public class TheatreDbContext : DbContext
{
    public TheatreDbContext( DbContextOptions<TheatreDbContext> options )
        : base( options )
    { }

    //Sets
    public DbSet<Theatre> Theatres { get; set; }
    public DbSet<Composition> Compositions { get; set; }
    public DbSet<Play> Plays { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Hours> Hours { get; set; }

    protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
    {
        base.OnConfiguring( optionsBuilder );
        if ( !optionsBuilder.IsConfigured ) // Проверка настройки через DI
        {
            optionsBuilder.UseSqlServer( "Server=localhost\\SQLEXPRESS01;Database=Theatre;Trusted_Connection=true;TrustServerCertificate=True;" );
        }
    }
    //DESKTOP-K8CC1AG\SQLEXPRESS01
    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        base.OnModelCreating( modelBuilder );

        modelBuilder.ApplyConfigurationsFromAssembly( GetType().Assembly );
    }
}
