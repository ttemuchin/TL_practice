using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Foundation.Configurations
{
    public class CompositionConfiguration : IEntityTypeConfiguration<Composition>
    {
        public void Configure( EntityTypeBuilder<Composition> builder )
        {
            builder.ToTable( "compositions" )
                .HasKey( p => p.CompositionId );

            builder.Property( p => p.CompositionId )
                .HasComment( "Id композиции" )
                .HasColumnName( "composition_id" )
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property( p => p.Description )
                .HasComment( "Oписание" )
                .HasColumnName( "description" )
                .IsRequired();

            builder.Property( p => p.Name )
                .HasComment( "Название композиции" )
                .HasColumnName( "name" )
                .HasMaxLength( 50 )
                .IsRequired();

            builder.Property( p => p.AuthorId )
                .HasComment( "Id автора" )
                .HasColumnName( "author_id" )
                .IsRequired();

            builder.Property( p => p.Heroes )
                .HasComment( "Информация о действующих лицах" )
                .HasColumnName( "heroes_information" )
                .IsRequired();

            builder.HasMany( p => p.Plays )
                .WithOne( c => c.Composition )
                .HasForeignKey( c => c.CompositionId )
                .OnDelete( DeleteBehavior.Cascade );
        }
    }
}
