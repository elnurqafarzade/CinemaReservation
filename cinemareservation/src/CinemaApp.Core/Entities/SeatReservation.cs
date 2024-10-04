using CinemaApp.Core.Entities.Base;
using Microsoft.PowerBI.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Core.Entities
{
    public class SeatReservation : BaseEntity
    {
        public int UserId { get; set; }
        public int ShowTimeId { get; set; }
        public string SeatNumber { get; set; }
        public bool IsBooked { get; set; }
        public int ReservationId { get; set; }
        public AppUser User { get; set; }
        public Reservation Reservation { get; set; }
        public ShowTime ShowTime { get; set; }
    }
}
