using CinemaApp.Business.DTOs.ReservationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Business.DTOs.ShowTimeDTOs
{
    public record ShowTimeGetDTO(int Id, DateTime StartTime, DateTime EndTime, bool IsDeleted, int MovieId, int TheaterId, string MovieTitle,
                                 string TheaterName, DateTime CreatedDate, DateTime ModifiedDate, ICollection<ReservationGetDTO>? Reservations) { }
}

    