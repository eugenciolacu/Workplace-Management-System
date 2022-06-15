using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Service.Exception
{
    public class IdentityException : ApiException
    {
        public IdentityException(string message) : base(HttpStatusCode.BadGateway, message)
        {
        }
    }
}
