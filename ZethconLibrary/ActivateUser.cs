using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZethconLibrary
{
    internal class ActivateUser
    {
        internal static ActivateUserResponseModel ActivateUserMethod(ActivateUserRequestModel requestApp)
        {
            ActivateUserResponseModel responseModel = new ActivateUserResponseModel();
            ErrorResponseModel errResp = new ErrorResponseModel();
            RequestException httpEx = new RequestException();

            try
            {
                var client = new RestClient("https://wds.zethconapptest.com/activateuser");
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("undefined", JObject.FromObject(requestApp), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                switch(response.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        //convert response to object
                        responseModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ActivateUserResponseModel>(response.Content);
                        break;
                    case System.Net.HttpStatusCode.BadRequest:
                        //convert error to object
                        errResp = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorResponseModel>(response.Content);
                        //throw custom exception
                        httpEx = new RequestException(errResp.error.message);
                        httpEx.Data.Add("HttpStatusCode", response.StatusCode);
                        httpEx.Data.Add("ErrorType", errResp.error.type);
                        throw httpEx;
                    case System.Net.HttpStatusCode.Unauthorized:
                        //convert error to object
                        errResp = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorResponseModel>(response.Content);
                        //throw custom exception
                        httpEx = new RequestException(errResp.error.message);
                        httpEx.Data.Add("HttpStatusCode", response.StatusCode);
                        httpEx.Data.Add("ErrorType", errResp.error.type);
                        throw httpEx;
                    case System.Net.HttpStatusCode.InternalServerError:
                        //convert error to object
                        errResp = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorResponseModel>(response.Content);
                        //throw custom exception
                        httpEx = new RequestException(errResp.error.message);
                        httpEx.Data.Add("HttpStatusCode", response.StatusCode);
                        httpEx.Data.Add("ErrorType", errResp.error.type);
                        throw httpEx;
                    default:
                        //throw custom exception
                        httpEx.Data.Add("HttpStatusCode", response.StatusCode);
                        throw httpEx;
                }                

            }
            catch(RequestException ex)
            {
                throw ex;
            }

            return responseModel;
        }

        
    }

    #region Structure

    public struct ActivateUserResponseModel
    {
        public string User;

        public ActivateUserResponseModel(string user)
        {
            User = user;
        }
    }

    public class Request
    {
        public string nameid { get; set; }
    }

    public class ActivateUserRequestModel
    {
        public string authtoken { get; set; }
        public Request request { get; set; }
    }

    #endregion


}
