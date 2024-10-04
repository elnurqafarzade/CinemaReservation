using CinemaApp.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Core.Entities
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public int Duration { get; set; }
        public double Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genres { get; set; }
        public ICollection<ShowTime>? ShowTimes { get; set; }

    }
}
