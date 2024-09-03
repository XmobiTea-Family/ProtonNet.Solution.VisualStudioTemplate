using System.Threading.Tasks;
using XmobiTea.Data.Converter.Rpc;
using XmobiTea.ProtonNet.Networking;
using XmobiTea.ProtonNet.Server.Handlers;
using XmobiTea.ProtonNet.Server.Handlers.Attributes;
using XmobiTea.ProtonNet.Server.Models;

namespace $safeprojectname$.Handlers
{
    /// <summary>
    /// Represents the model used for handling requests with string, boolean, and float data.
    /// </summary>
    class ModelRequestModel
    {
        /// <summary>
        /// A string value for the request model.
        /// </summary>
        [StringDataMember(Code = "testString")]
        public string TestString;

        /// <summary>
        /// A boolean value for the request model.
        /// </summary>
        [BooleanDataMember(Code = "testBoolean")]
        public bool TestBoolean;

        /// <summary>
        /// A float value representing the minimum float in the request model.
        /// </summary>
        [NumberDataMember(Code = "testFloatMin")]
        public float TestFloatMin;

    }

    /// <summary>
    /// Handles requests with a model containing string, boolean, and float data anonymously.
    /// </summary>
    [AllowAnonymous]
    class ModelRequestHandler : RequestHandler<ModelRequestModel>
    {
        /// <summary>
        /// Retrieves the operation code associated with this request handler.
        /// </summary>
        /// <returns>Returns the operation code as a string.</returns>
        public override string GetOperationCode() => "modelRequest";

        /// <summary>
        /// Processes the incoming request model and logs the details.
        /// </summary>
        /// <param name="requestModel">The model containing the request data.</param>
        /// <param name="operationRequest">The incoming operation request from the client.</param>
        /// <param name="sendParameters">Parameters used to send the response back to the client.</param>
        /// <param name="userPeer">The user peer initiating the request.</param>
        /// <param name="session">The current session associated with the request.</param>
        /// <returns>Returns an <see cref="OperationResponse"/> containing the result of the operation.</returns>
        public override async Task<OperationResponse> Handle(ModelRequestModel requestModel, OperationRequest operationRequest, SendParameters sendParameters, IUserPeer userPeer, ISession session)
        {
            this.logger.Info("Receive request model: " + requestModel.TestString + " " + requestModel.TestFloatMin + " " + requestModel.TestBoolean);

            return new OperationResponse(operationRequest.OperationCode)
            {
                DebugMessage = "a debug message from web api server",
                Parameters = operationRequest.Parameters,
                ReturnCode = ReturnCode.Ok,
            };
        }

    }

}
