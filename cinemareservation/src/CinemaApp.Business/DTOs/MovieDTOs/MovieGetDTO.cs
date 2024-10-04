using CinemaApp.Business.DTOs.ShowTimeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Business.DTOs.MovieDTOs
{
    public record MovieGetDTO(int Id, string Title, string? Description, int Duration, double? Rating, bool IsDeleted, DateTime CreatedDate,
                              DateTime ModifiedDate, string Genre, DateTime ReleaseDate, ICollection<ShowTimeGetDTO>? ShowTimes);
}
