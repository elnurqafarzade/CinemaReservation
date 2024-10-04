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
    public class SeatReservationConfiguration : IEntityTypeConfiguration<SeatReservation>
    {
        public void Configure(EntityTypeBuilder<SeatReservation> builder)
        {
            builder.Property(x => x.ReservationId)
                 .IsRequired();

            builder.Property(x => x.SeatNumber)
                .IsRequired();

            builder.Property(x => x.IsBooked)
                .IsRequired();

            builder.HasOne(x => x.Reservation)
                .WithMany(x => x.SeatReservations)
                .HasForeignKey(x => x.ReservationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
