using CinemaApp.Core.Entities.Base;
using CinemaApp.Core.Enums;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public string Fullname { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }


    }
}
