using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Business.Exceptions
{
    public class EntityNotFound : Exception
    {
        public int StatusCode { get; set; } = 404;
        public string? PropertyName { get; set; }
        public EntityNotFound()
        {
        }

        public EntityNotFound(string? message) : base(message)
        {
        }
        public EntityNotFound(int statusCode, string propertyName, string? message) : base(message)
        {
            StatusCode = statusCode;
            PropertyName = propertyName;
        }
    }
}
