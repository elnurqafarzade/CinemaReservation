using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Business.DTOs.SeatReservationDTOs
{
    public record SeatReservationGetDTOint Id, string SeatNumber, bool IsBooked, int ReservationId, bool IsDeleted,
                                        DateTime CreatedDate, DateTime ModifiedDate)
    {
    }
}
