using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Foundation.Configurations
{
    public class TheatreConfiguration : IEntityTypeConfiguration<Theatre>
    {
        public void Configure( EntityTypeBuilder<Theatre> builder )
        {
            builder.ToTable( "theatres" )
                .HasKey( t => t.Id );

            builder.Property( t => t.Id )
                .HasComment( "Id театра" )
                .HasColumnName( "theatre_id" )
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property( t => t.Name )
                .HasComment( "Название" )
                .HasColumnName( "name" )
                .HasMaxLength( 100 )
                .IsRequired();

            builder.Property( t => t.Address )
                .HasComment( "Адрес" )
                .HasColumnName( "address" )
                .HasMaxLength( 250 )
                .IsRequired();

            builder.Property( t => t.OpeningDate )
                .HasComment( "Дата открытия театра" )
                .HasColumnName( "first_opening_date" )
                .IsRequired();

            builder.Property( t => t.Description )
                .HasComment( "Описание" )
                .HasColumnName( "description" )
                .IsRequired();

            builder.Property( t => t.PhoneNumber )
                .HasComment( "Номер администрации" )
                .HasColumnName( "phone_number" )
                .HasMaxLength( 20 )
                .IsRequired();

            builder.HasMany( t => t.Plays )
                .WithOne( p => p.Theatre )
                .HasForeignKey( p => p.TheatreId )
                .OnDelete( DeleteBehavior.Cascade );

            builder.HasMany( t => t.TheaterHours )
                .WithOne( p => p.Theatre )
                .HasForeignKey( p => p.TheatreId )
                .OnDelete( DeleteBehavior.Cascade );
        }
    }
}
