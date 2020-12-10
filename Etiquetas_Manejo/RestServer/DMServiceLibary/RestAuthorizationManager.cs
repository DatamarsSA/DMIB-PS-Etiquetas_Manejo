using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web;

namespace DMServiceLibrary
{
    public class RestAuthorizationManager : ServiceAuthorizationManager
    {
        protected override bool CheckAccessCore(OperationContext operationContext)
        {
            var authHeader = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];
            if((authHeader != null) && (authHeader != String.Empty))
            {
                String[] svcCredetial = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(authHeader.Substring(6))).Split(':');
                var user = new { Name = svcCredetial[0], Password = svcCredetial[1] };
                if((user.Name == "testUser" && user.Password == "testPass"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                WebOperationContext.Current.OutgoingResponse.Headers.Add("WWW-Authenticate: Basic realm=\"ProductionService\"");
                throw new WebFaultException(System.Net.HttpStatusCode.Unauthorized);
            }
        }
    }
}