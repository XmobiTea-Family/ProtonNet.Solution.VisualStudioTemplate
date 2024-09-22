using System.Threading.Tasks;
using XmobiTea.Data.Converter.Rpc;
using XmobiTea.ProtonNet.Networking;
using XmobiTea.ProtonNet.Server.Handlers;
using XmobiTea.ProtonNet.Server.Handlers.Attributes;
using XmobiTea.ProtonNet.Server.Models;

namespace $rootnamespace$
{
    class $fileinputname$RequestModel
    {
        [StringDataMember(Code = "templateString")]
        public string TemplateString;

    }

    [AllowAnonymous]
    class $safeitemname$ : RequestHandler<$fileinputname$RequestModel>
    {
        public override string GetOperationCode() => "$fileinputname$";

        public override async Task<OperationResponse> Handle($fileinputname$RequestModel requestModel, OperationRequest operationRequest, SendParameters sendParameters, IUserPeer userPeer, ISession session)
        {
            return new OperationResponse(operationRequest.OperationCode)
            {
                ReturnCode = ReturnCode.OperationInvalid,
            };
        }

    }

}
