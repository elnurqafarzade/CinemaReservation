using CinemaApp.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Core.Entities
{
    public class Reservation : BaseEntity
    {
        public DateTime ReservationDate { get; set; }
        public string UserId { get; set; }
        public int ShowTimeId { get; set; }
        public AppUser AppUser  { get; set; }
        public ShowTime ShowTime { get; set; }
        public ICollection<SeatReservation>? SeatReservations { get; set; }

    }
}
