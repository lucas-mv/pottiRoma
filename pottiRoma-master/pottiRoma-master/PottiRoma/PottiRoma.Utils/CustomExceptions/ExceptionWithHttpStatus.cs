using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Utils.CustomExceptions
{
    public class ExceptionWithHttpStatus : Exception
    {
        private HttpStatusCode StatusCode;

        public ExceptionWithHttpStatus(HttpStatusCode statusCode, string message)
            : base(message)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode GetStatusCode()
        {
            return StatusCode;
        }
    }
}
