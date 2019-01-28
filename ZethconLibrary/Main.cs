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

    public struct ErrorResponseModel
    {
        public string Error;
        public ErrorResponse[] ErrorResponse;

        public ErrorResponseModel(string error, ErrorResponse[] errorResponse)
        {
            Error = error;
            ErrorResponse = errorResponse;
        }
    }

    public struct ErrorResponse
    {
        public string Type;
        public string Message;

        public ErrorResponse(string type, string message)
        {
            Type = type;
            Message = message;
        }
    }

    #endregion
}
