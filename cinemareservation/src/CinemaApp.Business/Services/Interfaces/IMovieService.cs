using CinemaApp.Business.DTOs.MovieDTOs;
using CinemaApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Business.Services.Interfaces
{
    public interface IMovieService
    {
        Task<MovieGetDTO> CreateAsync(MovieCreateDTO dto);
        Task DeleteAsync(int id);
        Task UpdateAsync(int? id, MovieUpdateDTO dto);
        Task<MovieGetDTO> GetByIdAsync(int id);
        Task<bool> IsExistAsync(Expression<Func<Movie, bool>>? expression = null);
        Task<ICollection<MovieGetDTO>> GetByExpressionAsync(bool asNoTracking = false, Expression<Func<Movie, bool>>? expression = null, params string[] includes);
        Task<MovieGetDTO> GetSingleByExpressionAsync(bool asNoTracking = false, Expression<Func<Movie, bool>>? expression = null, params string[] includes);
    }
}
