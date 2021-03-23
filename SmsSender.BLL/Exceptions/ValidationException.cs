using System;
using System.Net;

namespace SmsSender.BLL.Exceptions
{
    public class ValidationException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public ValidationException() : base() { }

        public ValidationException(string message) : base(message) { }

        public ValidationException(string message, Exception innerException) : base(message, innerException) { }

        public ValidationException(HttpStatusCode statusCode, string msg) : base($"BAD_REQUEST {msg}")
        {
            StatusCode = statusCode;
        }
    }
}
