using AutoMapper;
using CinemaApp.Business.DTOs.MovieDTOs;
using CinemaApp.Business.Services.Interfaces;
using CinemaApp.Core.Entities;
using CinemaApp.Core.Repositories;
using CinemaApp.Data.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Business.Services.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly IMapper mapper;
        private readonly IMovieRepository movieRepository;

        public MovieService(IMapper mapper, IMovieRepository movieRepository)
        {
            this.mapper = mapper;
            this.movieRepository = movieRepository;
        }
        public async Task<MovieGetDTO> CreateAsync(MovieCreateDTO dto)
        {
            Movie movie = mapper.Map<Movie>(dto);
            movie.CreatedDate = DateTime.Now;
            movie.IsDeleted = false;
            await movieRepository.CreateAsync(movie);
            await movieRepository.CommitAsync();

            MovieGetDTO getDto = mapper.Map<MovieGetDTO>(movie);

            return getDto;
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1) throw new InvalidIdException(400, "", "Id cant be less than 1 or null");
            var data = await movieRepository.GetByIdAsync(id);
            if (data == null) throw new EntityNotFoundException(404, "", "Movie Not Found");
            movieRepository.Delete(data);
            await movieRepository.CommitAsync();
        }

        public async Task<ICollection<MovieGetDTO>> GetByExpressionAsync(bool asNoTracking = false, Expression<Func<Movie, bool>>? expression = null, params string[] includes)
        {
            var datas = await movieRepository.GetByExpression(asNoTracking, expression, includes).ToListAsync();
            if (datas == null) throw new EntityNotFoundException(404, "", "Movie Not Found");

            ICollection<MovieGetDTO> dtos = mapper.Map<ICollection<MovieGetDTO>>(datas);
            return dtos;

        }

        public async Task<MovieGetDTO> GetByIdAsync(int id)
        {
            if (id < 1) throw new InvalidIdException(400, "", "Id cant be less than 1 or null");
            ;
            var data = await movieRepository.GetByIdAsync(id);
            if (data == null) throw new EntityNotFoundException(404, "", "Movie Not Found");
            MovieGetDTO dto = mapper.Map<MovieGetDTO>(data);
            return dto;
        }

        public async Task<MovieGetDTO> GetSingleByExpressionAsync(bool asNoTracking = false, Expression<Func<Movie, bool>>? expression = null, params string[] includes)
        {
            var data = await movieRepository.GetByExpression(asNoTracking, expression, includes).FirstOrDefaultAsync();
            if (data == null) throw new EntityNotFoundException(404, "", "Movie Not Found");

            MovieGetDTO dto = mapper.Map<MovieGetDTO>(data);
            return dto;
        }

        public async Task<bool> IsExistAsync(Expression<Func<Movie, bool>>? expression = null)
        {
            return await movieRepository.Table.AnyAsync(expression);
        }

        public async Task UpdateAsync(int? id, MovieUpdateDTO dto)
        {
            if (id < 1 || id is null) throw new InvalidIdException(400, "", "Id cant be less than 1 or null");

            var data = await movieRepository.GetByIdAsync((int)id);
            if (data == null) throw new EntityNotFoundException(404, "", "Movie Not Found");

            mapper.Map(dto, data);

            data.ModifiedDate = DateTime.Now;
            await movieRepository.CommitAsync();
        }
    }
}

