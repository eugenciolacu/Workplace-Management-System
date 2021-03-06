using System.Net;

namespace WMS.Service.Exceptions
{
    public class ApiException : IOException
    {
        public HttpStatusCode Code { get; }

        public ApiException(HttpStatusCode code, string message) : base(message)
        {
            Code = code;
        }
    }
}
