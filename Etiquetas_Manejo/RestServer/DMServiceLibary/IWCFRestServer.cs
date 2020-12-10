using ProductionData;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace DMServiceLibrary
{
    [ServiceContract]
    public interface IWCFRestServer
    {
        [OperationContract]
        [WebInvoke(Method = @"POST",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = @"/api/v1/create")]
        bool CreateProduction(DMProductionOrder[] orders);

        [OperationContract]
        [WebInvoke(Method = @"POST",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = @"/api/v1/cancel")]
        bool CancelProduction(string[] ids);

        [OperationContract]
        [WebInvoke(Method = @"POST",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = @"/api/FSv1/create")]
        bool FS_CreateProduction(FSProductionOrder[] orders);

        [OperationContract]
        [WebInvoke(Method = @"POST",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = @"/api/FSv1/cancel")]
        bool FS_CancelProduction(string[] ids);
    }
}
