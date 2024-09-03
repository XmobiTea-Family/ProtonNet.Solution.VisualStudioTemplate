using System.Threading.Tasks;
using XmobiTea.ProtonNet.Networking;
using XmobiTea.ProtonNet.Server.Handlers;
using XmobiTea.ProtonNet.Server.Handlers.Attributes;
using XmobiTea.ProtonNet.Server.Models;

namespace $rootnamespace$
{
    [AllowAnonymous]
    class $safeitemname$ : RequestHandler
    {
        public override string GetOperationCode() => "$fileinputname$";

        public override async Task<OperationResponse> Handle(OperationRequest operationRequest, SendParameters sendParameters, IUserPeer userPeer, ISession session)
        {
            return new OperationResponse(operationRequest.OperationCode)
            {
                ReturnCode = ReturnCode.OperationInvalid,
            };
        }

    }

}
