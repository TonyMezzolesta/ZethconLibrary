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
                request.AddParameter("undefined", requestApp, ParameterType.RequestBody);
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
                        httpEx = new RequestException(errResp.ErrorResponse[0].Message);
                        httpEx.Data.Add("HttpStatusCode", response.StatusCode);
                        httpEx.Data.Add("ErrorType", errResp.ErrorResponse[0].Type);
                        throw httpEx;
                    case System.Net.HttpStatusCode.Unauthorized:
                        //convert error to object
                        errResp = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorResponseModel>(response.Content);
                        //throw custom exception
                        httpEx = new RequestException(errResp.ErrorResponse[0].Message);
                        httpEx.Data.Add("HttpStatusCode", response.StatusCode);
                        httpEx.Data.Add("ErrorType", errResp.ErrorResponse[0].Type);
                        throw httpEx;
                    case System.Net.HttpStatusCode.InternalServerError:
                        //convert error to object
                        errResp = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorResponseModel>(response.Content);
                        //throw custom exception
                        httpEx = new RequestException(errResp.ErrorResponse[0].Message);
                        httpEx.Data.Add("HttpStatusCode", response.StatusCode);
                        httpEx.Data.Add("ErrorType", errResp.ErrorResponse[0].Type);
                        throw httpEx;
                    default:
                        //throw custom exception
                        httpEx = new RequestException();
                        httpEx.Data.Add("HttpStatusCode", response.StatusCode);
                        throw httpEx;
                }                

            }
            catch(Exception ex)
            {
                throw ex;
            }

            return responseModel;
        }

        
    }

    #region Structure

    public struct ActivateUserRequestModel
    {
        public string AuthToken;
        public ActivateUserRequest[] ActivateUserRequest;

        public ActivateUserRequestModel(string authtoken, ActivateUserRequest[] activateUserRequest)
        {
            AuthToken = authtoken;
            ActivateUserRequest = activateUserRequest;
        }
    }

    public struct ActivateUserRequest
    {
        public string Nameid;

        public ActivateUserRequest(string nameid)
        {
            Nameid = nameid;
        }
    }

    public struct ActivateUserResponseModel
    {
        public string User;

        public ActivateUserResponseModel(string user)
        {
            User = user;
        }
    }

    #endregion


}
