using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Business.DTOs.ShowTimeDTOs
{
    public record ShowTimeCreateDTO(DateTime StartTime, DateTime EndTime, int MovieId, int TheaterId, bool IsDeleted)
    {
    }
}
