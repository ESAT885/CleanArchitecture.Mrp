using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.Mrp.Application.Exceptions
{
    public class BusinessException : AppException
    {
        public BusinessException(string publicMessage, string logMessage) :
            base(publicMessage, logMessage, StatusCodes.Status400BadRequest)
        { }
    }

    public class NotFoundException : AppException
    {
        public NotFoundException(string publicMessage, string logMessage)
            : base(publicMessage, logMessage, StatusCodes.Status404NotFound) { }
    }

    public class UnauthorizedException : AppException
    {
        public UnauthorizedException(string publicMessage, string logMessage)
            : base(publicMessage, logMessage, StatusCodes.Status401Unauthorized) { }
    }
}
