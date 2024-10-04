using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Business.DTOs.MovieDTOs
{
    public record MovieUpdateDTO(string Title, string? Description, int Duration, double? Rating, bool IsDeleted, string Genre, DateTime ReleaseDate);

    public class MovieUpdateDtoValidator : AbstractValidator<MovieCreateDTO>
    {
        public MovieUpdateDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MinimumLength(2).WithMessage("Min length must be 1")
                .MaximumLength(200).WithMessage("Length must be less than 200");

            RuleFor(x => x.Description)
                .NotNull().When(x => !x.IsDeleted).WithMessage("If movie is active description cannot be null")
                .MaximumLength(800).WithMessage("Length must be less than 800");

            RuleFor(x => x.IsDeleted).NotNull();

            RuleFor(x => x.Genre).NotNull().NotEmpty();
        }
    }
  }
