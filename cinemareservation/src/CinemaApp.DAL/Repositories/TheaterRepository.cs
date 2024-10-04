using CinemaApp.Core.Entities;
using CinemaApp.Core.Repositories;
using CinemaApp.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.Repositories
{
    public class TheaterRepository : GenericRepository<Theater>, ITheaterRepository
    {
        public TheaterRepository(AppDBContext context) : base(context) { }
    }
}
