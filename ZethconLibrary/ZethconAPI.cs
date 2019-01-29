using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//name all of the public functions with API at the end so that it can be noticed in the test gui

namespace ZethconLibrary
{
    public class ZethconAPI
    {
        public static ActivateUserResponseModel ActivateUserAPI(ActivateUserRequestModel requestApp)
        {
            try
            {
                return ActivateUser.ActivateUserMethod(requestApp);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
