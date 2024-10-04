using CinemaApp.Core.Entities;
using CinemaApp.Core.Repositories;
using CinemaApp.Data.DAL;
using CinemaApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.Repositorysitories
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(AppDBContext context) : base(context) { }
    }
}
