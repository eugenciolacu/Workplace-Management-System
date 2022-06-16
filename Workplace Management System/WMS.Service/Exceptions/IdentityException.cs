using System.Net;

namespace WMS.Service.Exceptions
{
    public class IdentityException : ApiException
    {
        public IdentityException(string message) : base(HttpStatusCode.BadGateway, message)
        {
        }
    }
}
