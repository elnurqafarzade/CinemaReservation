using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Business.Exceptions
{
    public class InvalidId : Exception
    {
        public int StatusCode { get; set; } = 400;
        public string? PropertyName { get; set; }
        public InvalidId()
        {
        }

        public InvalidId(string? message) : base(message)
        {
        }

        public InvalidId(int statusCode, string propertyName, string? message) : base(message)
        {
            StatusCode = statusCode;
            PropertyName = propertyName;
        }
    }
}
