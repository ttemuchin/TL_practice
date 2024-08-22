using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Foundation.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure( EntityTypeBuilder<Author> builder )
        {
            builder.ToTable( "authors" )
                .HasKey( p => p.Id );

            builder.Property( p => p.Id )
                .HasComment( "Id автора" )
                .HasColumnName( "author_id" )
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property( p => p.Name )
                .HasComment( "ФИО автора" )
                .HasColumnName( "name" )
                .HasMaxLength( 120 )
                .IsRequired();

            builder.Property( p => p.DateOfBirth )
                .HasComment( "Дата рождения" )
                .HasColumnName( "birthday" )
                .IsRequired();

            builder.HasMany( p => p.Compositions )
                .WithOne( p => p.Author )
                .HasForeignKey( p => p.AuthorId )
                .OnDelete( DeleteBehavior.Cascade );
        }
    }
}
