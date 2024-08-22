using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Foundation.Configurations
{
    public class PlayConfiguration : IEntityTypeConfiguration<Play>
    {
        public void Configure( EntityTypeBuilder<Play> builder )
        {
            builder.ToTable( "plays" )
                .HasKey( p => p.Id );

            builder.Property( p => p.Id )
                .HasComment( "Id представления" )
                .HasColumnName( "play_id" )
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property( p => p.Name )
                .HasComment( "Название" )
                .HasColumnName( "name" )
                .HasMaxLength( 150 )
                .IsRequired();

            builder.Property( p => p.StartDate )
                .HasComment( "Дата начала" )
                .HasColumnName( "start_date" )
                .IsRequired();

            builder.Property( p => p.EndDate )
                .HasComment( "Дата завершения" )
                .HasColumnName( "end_date" )
                .IsRequired();

            builder.Property( p => p.TicketPrice )
                .HasComment( "Цена билета" )
                .HasColumnName( "ticket_price" )
                .IsRequired();

            builder.Property( p => p.Description )
                .HasComment( "Описание" )
                .HasColumnName( "description" )
                .IsRequired();

            builder.Property( p => p.TheatreId )
                .HasComment( "Id театра" )
                .HasColumnName( "theater_id" )
                .IsRequired();

            builder.Property( p => p.CompositionId )
                .HasComment( "Id композиции" )
                .HasColumnName( "composition_id" )
                .IsRequired();

            builder.HasOne( p => p.Theatre )
                .WithMany( t => t.Plays )
                .HasForeignKey( p => p.TheatreId )
                .OnDelete( DeleteBehavior.Cascade );

            builder.HasOne( p => p.Composition )
                .WithMany( k => k.Plays )
                .HasForeignKey( p => p.CompositionId )
                .OnDelete( DeleteBehavior.Cascade );
        }
    }
}
