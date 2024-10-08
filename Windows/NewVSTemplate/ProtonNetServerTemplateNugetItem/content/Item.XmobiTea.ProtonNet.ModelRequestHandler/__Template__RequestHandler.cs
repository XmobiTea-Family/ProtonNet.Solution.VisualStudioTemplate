using System.Threading.Tasks;
using XmobiTea.Data.Converter.Rpc;
using XmobiTea.ProtonNet.Networking;
using XmobiTea.ProtonNet.Server.Handlers;
using XmobiTea.ProtonNet.Server.Handlers.Attributes;
using XmobiTea.ProtonNet.Server.Models;

namespace __Namespace__
{
    class __CodePrefix__RequestModel
    {
        // Just demo field receive from client here, you can remove or replace with another.
        [StringDataMember(Code = "templateString")]
        public string TemplateString;

    }

    [AllowAnonymous]
    class __Template__RequestHandler : RequestHandler<__CodePrefix__RequestModel>
    {
        public override string GetOperationCode() => "__CodePrefix__";

        public override async Task<OperationResponse> Handle(__CodePrefix__RequestModel requestModel, OperationRequest operationRequest, SendParameters sendParameters, IUserPeer userPeer, ISession session)
        {
            // Handle and return the operation response with the provided request model

            return new OperationResponse(operationRequest.OperationCode)
            {
                ReturnCode = ReturnCode.OperationInvalid,
            };
        }

    }

}
