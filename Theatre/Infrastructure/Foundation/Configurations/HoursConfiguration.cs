using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Foundation.Configurations
{
    public class HoursConfiguration : IEntityTypeConfiguration<Hours>
    {
        public void Configure( EntityTypeBuilder<Hours> builder )
        {
            builder.ToTable( "hours" )
                .HasKey( p => p.Id );

            builder.Property( p => p.Id )
                .HasComment( "Id режима работы" )
                .HasColumnName( "hours_id" )
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property( p => p.Days )
                .HasComment( "День недели" )
                .HasColumnName( "days" )
                .IsRequired();

            builder.Property( p => p.OpeningTime )
                .HasComment( "Время открытия" )
                .HasColumnName( "opening_time" )
                .IsRequired();

            builder.Property( p => p.ClosingTime )
                .HasComment( "Время закрытия" )
                .HasColumnName( "closing_time" )
                .IsRequired();

            builder.Property( p => p.TheatreId )
                .HasComment( "Id театра" )
                .HasColumnName( "theater_id" )
                .IsRequired();

            builder.HasOne( p => p.Theatre )
                .WithMany( t => t.TheaterHours )
                .HasForeignKey( p => p.TheatreId )
                .OnDelete( DeleteBehavior.Cascade );
        }
    }
}
