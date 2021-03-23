using System.Net;

namespace SmsSender.Shared.Contracts.Responses
{
    public class ApiResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }

        public T Data { get; set; }
    }
}
