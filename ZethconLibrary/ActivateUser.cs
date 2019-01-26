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

            try
            {
                var client = new RestClient("https://wds.zethconapptest.com/activateuser");
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("undefined", requestApp, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                //convert response to object
                responseModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ActivateUserResponseModel>(response.Content);
            }
            catch(Exception ex)
            {

            }

            return responseModel;
        }

        
    }

    #region Structure

    public struct ActivateUserRequestModel
    {
        public string AuthToken;
        public ActivateUserRequest ActivateUserRequest;

        public ActivateUserRequestModel(string authtoken, ActivateUserRequest activateUserRequest)
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

    #region Response exception

    public class ActivateUserRequestException : Exception
    {
        public ActivateUserRequestException(string message)
            : base(message)
        {
        }
    }

    #endregion
}
