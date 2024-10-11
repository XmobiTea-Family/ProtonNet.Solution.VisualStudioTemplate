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
        // Just demo field receive from client here, you can remove or replace with another.
        [StringDataMember(Code = "templateString")]
        public string TemplateString;

    }

    [AllowAnonymous]
    class $safeitemname$ : RequestHandler<$fileinputname$RequestModel>
    {
        public override string GetOperationCode() => "$fileinputname$";

        public override async Task<OperationResponse> Handle($fileinputname$RequestModel requestModel, OperationRequest operationRequest, SendParameters sendParameters, IUserPeer userPeer, ISession session)
        {
            // Handle and return the operation response with the provided request model

            return new OperationResponse(operationRequest.OperationCode)
            {
                ReturnCode = ReturnCode.OperationInvalid,
            };
        }

    }

}
