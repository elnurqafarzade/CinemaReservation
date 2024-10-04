using CinemaApp.Business.DTOs.SeatReservationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Business.DTOs.ReservationDTOs
{
    public record ReservationGetDTO(int Id, DateTime ReservationDate, string AppUserId, int ShowTimeId, bool IsDeleted, DateTime CreatedDate,
                                    DateTime ModifiedDate, ICollection<SeatReservationGetDTO>? SeatReservations)
    {
    }
}
