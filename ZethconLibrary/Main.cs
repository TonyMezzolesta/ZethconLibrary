using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZethconLibrary
{
    internal class Main
    {

    }

    #region Response exception

    public class RequestException : Exception
    {
        public RequestException()
        {
        }

        public RequestException(string message)
            : base(message)
        {
        }

        public RequestException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    #endregion

    #region Reponse Error Object

    public class Error
    {
        public string type { get; set; }
        public string message { get; set; }
    }

    public class ErrorResponseModel
    {
        public Error error { get; set; }
    }

    #endregion
}
