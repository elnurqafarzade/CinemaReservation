using CinemaApp.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Core.Entities
{
    public class Theater : BaseEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public int TotalSeats { get; set; }
        public ICollection<ShowTime>? ShowTimes { get; set; }
    }
}
