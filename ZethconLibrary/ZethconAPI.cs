using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
