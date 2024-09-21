using XmobiTea.Bean.Attributes;
using XmobiTea.Data.Converter.Rpc;
using XmobiTea.ProtonNet.Networking;
using XmobiTea.ProtonNet.Server.Handlers;
using XmobiTea.ProtonNet.Server.Handlers.Attributes;
using XmobiTea.ProtonNet.Server.Models;
using XmobiTea.ProtonNet.Server.Socket.Services;
using XmobiTea.ProtonNet.Server.Socket.Sessions;

namespace $safeprojectname$.Handlers
{
    /// <summary>
    /// Represents the model used for handling events with string, boolean, and float data.
    /// </summary>
    class ModelEventModel
    {
        /// <summary>
        /// A string value for the event model.
        /// </summary>
        [StringDataMember(Code = "testString")]
        public string TestString;

        /// <summary>
        /// A boolean value for the event model.
        /// </summary>
        [BooleanDataMember(Code = "testBoolean")]
        public bool TestBoolean;

        /// <summary>
        /// A float value representing the minimum float in the event model.
        /// </summary>
        [NumberDataMember(Code = "testFloatMin")]
        public float TestFloatMin;

    }

    /// <summary>
    /// Handles events with a model containing string, boolean, and float data anonymously.
    /// </summary>
    [AllowAnonymous]
    class ModelEventHandler : EventHandler<ModelEventModel>
    {
        /// <summary>
        /// Automatically binds an implementation of ISocketSessionEmitService to this property.
        /// </summary>
        [AutoBind]
        private ISocketSessionEmitService socketSessionEmitService { get; set; }

        /// <summary>
        /// Retrieves the event code associated with this event handler.
        /// </summary>
        /// <returns>Returns the event code as a string.</returns>
        public override string GetEventCode() => "modelEvent";

        /// <summary>
        /// Processes the incoming event model, logs the event details, and sends an event back to the client.
        /// </summary>
        /// <param name="eventModel">The model containing the event data.</param>
        /// <param name="operationEvent">The incoming operation event from the client.</param>
        /// <param name="sendParameters">Parameters used to send the response back to the client.</param>
        /// <param name="userPeer">The user peer initiating the event.</param>
        /// <param name="session">The current session associated with the event.</param>
        public override void Handle(ModelEventModel eventModel, OperationEvent operationEvent, SendParameters sendParameters, IUserPeer userPeer, ISession session)
        {
            this.logger.Info("Receive event model: " + eventModel.TestString + " " + eventModel.TestFloatMin + " " + eventModel.TestBoolean);

            // Handle the event with the provided operation event

            this.socketSessionEmitService.SendOperationEvent((ISocketSession)session, new OperationEvent()
            {
                EventCode = "modelEventFromServer",
                Parameters = operationEvent.Parameters
            }, sendParameters);
        }

    }

}
