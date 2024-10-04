using CinemaApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.Data.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie> 
    {
        public void Configure(EntityTypeBuilder<Movie> builder) 
        {
            builder.Property(x => x.Title)
              .IsRequired()
              .HasMaxLength(200);

            builder.Property(x => x.Description)
                .IsRequired(false)
                .HasMaxLength(800);

            builder.Property(x => x.Duration)
                .IsRequired();

            builder.Property(x => x.Rating)
                       .IsRequired(false)
                       .HasPrecision(3, 2);

            builder.Property(x => x.Genres)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.ReleaseDate)
                .IsRequired();


        }

    }
    
}
