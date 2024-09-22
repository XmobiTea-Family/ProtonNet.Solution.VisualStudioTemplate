using System.Threading.Tasks;
using XmobiTea.ProtonNet.Networking;
using XmobiTea.ProtonNet.Server.Handlers;
using XmobiTea.ProtonNet.Server.Handlers.Attributes;
using XmobiTea.ProtonNet.Server.Models;

namespace $safeprojectname$.Handlers
{
    /// <summary>
    /// Handles requests anonymously, allowing access without authentication.
    /// </summary>
    [AllowAnonymous]
    class NoModelRequestHandler : RequestHandler
    {
        /// <summary>
        /// Retrieves the operation code associated with this request handler.
        /// </summary>
        /// <returns>Returns the operation code as a string.</returns>
        public override string GetOperationCode() => "noModelRequest";

        /// <summary>
        /// Processes the operation request and returns an operation response.
        /// </summary>
        /// <param name="operationRequest">The incoming operation request from the client.</param>
        /// <param name="sendParameters">Parameters used to send the response back to the client.</param>
        /// <param name="userPeer">The user peer initiating the request.</param>
        /// <param name="session">The current session associated with the request.</param>
        /// <returns>Returns an <see cref="OperationResponse"/> containing the result of the operation.</returns>
        public override async Task<OperationResponse> Handle(OperationRequest operationRequest, SendParameters sendParameters, IUserPeer userPeer, ISession session)
        {
            return new OperationResponse(operationRequest.OperationCode)
            {
                DebugMessage = "a debug message from web api server",
                Parameters = operationRequest.Parameters,
                ReturnCode = ReturnCode.Ok,
            };
        }

    }

}
