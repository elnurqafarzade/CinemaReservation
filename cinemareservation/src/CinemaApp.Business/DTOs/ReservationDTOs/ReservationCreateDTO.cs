using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Business.DTOs.ReservationDTOs
{
    public record ReservationCreateDTO(DateTime ReservationDate, string AppUserId, int ShowTimeId, bool IsDeleted) {}


    public class ReservationCreateDTOValidator : AbstractValidator<ReservationCreateDTO>
    {
        public ReservationCreateDTOValidator()
        {
            RuleFor(x => x.ShowTimeId).NotNull().NotEmpty();
            RuleFor(x => x.AppUserId).NotNull().NotEmpty();
        }

    }
}
