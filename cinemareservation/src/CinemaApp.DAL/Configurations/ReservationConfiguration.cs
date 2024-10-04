
using CinemaApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(x => x.UserId)
               .IsRequired();

            builder.Property(x => x.ShowTimeId)
                .IsRequired();

            builder.Property(x => x.ReservationDate)
                .IsRequired();

            builder.HasOne(x => x.AppUser)
                .WithMany(x => x.Reservations)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.ShowTime)
                .WithMany(x => x.Reservations)
                .HasForeignKey(x => x.ShowTimeId);
        }
    }
}
