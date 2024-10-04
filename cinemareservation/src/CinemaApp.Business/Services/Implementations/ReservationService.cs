using AutoMapper;
using CinemaApp.Business.DTOs.ReservationDTOs;
using CinemaApp.Business.Exceptions;
using CinemaApp.Core.Entities;
using CinemaApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Business.Services.Implementations
{
    public class ReservationService
    {
        private readonly IReservationRepository reservationRepository;
        private readonly IMapper mapper;

        public ReservationService(IReservationRepository reservationRepository, IMapper mapper)
        {
            this.reservationRepository = reservationRepository;
            this.mapper = mapper;
        }
        public async Task<ReservationGetDTO> CreateAsync(ReservationCreateDTO dto)
        {
            Reservation reservation = mapper.Map<Reservation>(dto);
            reservation.CreatedDate = DateTime.Now;
            reservation.IsDeleted = false;
            await reservationRepository.CreateAsync(reservation);
            await reservationRepository.CommitAsync();

            ReservationGetDTO getDto = mapper.Map<ReservationGetDTO>(reservation);

            return getDto;
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1) throw new InvalidId();
            var data = await reservationRepository.GetByIdAsync(id);
            if (data == null) throw new EntityNotFound();
            reservationRepository.Delete(data);
            await reservationRepository.CommitAsync();
        }

        public async Task<ICollection<ReservationGetDTO>> GetByExpressionAsync(bool asNoTracking = false, Expression<Func<Reservation, bool>>? expression = null, params string[] includes)
        {
            var datas = await reservationRepository.GetByExpression(asNoTracking, expression, includes).ToListAsync();
            if (datas == null) throw new EntityNotFound();

            ICollection<ReservationGetDTO> dtos = mapper.Map<ICollection<ReservationGetDTO>>(datas);
            return dtos;
        }

        public async Task<ReservationGetDTO> GetByIdAsync(int id)
        {
            if (id < 1) throw new InvalidId();
            var data = await reservationRepository.GetByIdAsync(id);
            if (data == null) throw new EntityNotFound();
            ReservationGetDTO dto = mapper.Map<ReservationGetDTO>(data);
            return dto;
        }

        public async Task<ReservationGetDTO> GetSingleByExpressionAsync(bool asNoTracking = false, Expression<Func<Reservation, bool>>? expression = null, params string[] includes)
        {
            var data = await reservationRepository.GetByExpression(asNoTracking, expression, includes).FirstOrDefaultAsync();
            if (data == null) throw new EntityNotFound();

            ReservationGetDTO dto = mapper.Map<ReservationGetDTO>(data);

            return dto;
        }

        public async Task UpdateAsync(int? id, ReservationUpdateDTO dto)
        {
            if (id < 1 || id is null) throw new InvalidId();

            var data = await reservationRepository.GetByIdAsync((int)id);
            if (data == null) throw new EntityNotFound();

            mapper.Map(dto, data);

            await reservationRepository.CommitAsync();
        }

        public async Task<bool> IsExistAsync(Expression<Func<Reservation, bool>>? expression = null)
        {
            return await reservationRepository.Table.AnyAsync(expression);
        }
    }
}
