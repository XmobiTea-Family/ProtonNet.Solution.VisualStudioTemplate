using System.Threading.Tasks;
using XmobiTea.ProtonNet.Networking;
using XmobiTea.ProtonNet.Server.Handlers;
using XmobiTea.ProtonNet.Server.Handlers.Attributes;
using XmobiTea.ProtonNet.Server.Models;

namespace __Namespace__
{
    [AllowAnonymous]
    class __Template__RequestHandler : RequestHandler
    {
        public override string GetOperationCode() => "__CodePrefix__";

        public override async Task<OperationResponse> Handle(OperationRequest operationRequest, SendParameters sendParameters, IUserPeer userPeer, ISession session)
        {
            // Handle and return the operation response with the provided operation request

            return new OperationResponse(operationRequest.OperationCode)
            {
                ReturnCode = ReturnCode.OperationInvalid,
            };
        }

    }

}
