using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Mrp.Application.Exceptions
{
    public abstract class AppException : Exception
    {
        private int status400BadRequest;

        public int StatusCode { get; }
        public string PublicMessage { get; }
        protected AppException(
            string publicMessage,
            string logMessage,
            int statusCode)
            : base(logMessage ?? publicMessage)
        {
            StatusCode = statusCode;
            PublicMessage = publicMessage;
        }


    }
}
