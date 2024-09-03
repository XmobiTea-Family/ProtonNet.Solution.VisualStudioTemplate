using XmobiTea.Bean.Attributes;
using XmobiTea.ProtonNet.Networking;
using XmobiTea.ProtonNet.Server.Handlers;
using XmobiTea.ProtonNet.Server.Handlers.Attributes;
using XmobiTea.ProtonNet.Server.Models;
using XmobiTea.ProtonNet.Server.Socket.Services;
using XmobiTea.ProtonNet.Server.Socket.Sessions;

namespace $safeprojectname$.Handlers
{
    /// <summary>
    /// Handles events anonymously, allowing access without authentication.
    /// </summary>
    [AllowAnonymous]
    class NoModelEventHandler : EventHandler
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
        public override string GetEventCode() => "noModelEvent";

        /// <summary>
        /// Processes the incoming operation event, logs the event details, and sends an event back to the client.
        /// </summary>
        /// <param name="operationEvent">The incoming operation event from the client.</param>
        /// <param name="sendParameters">Parameters used to send the response back to the client.</param>
        /// <param name="userPeer">The user peer initiating the event.</param>
        /// <param name="session">The current session associated with the event.</param>
        public override void Handle(OperationEvent operationEvent, SendParameters sendParameters, IUserPeer userPeer, ISession session)
        {
            this.logger.Info("An event received from client " + operationEvent.EventCode + " " + operationEvent.Parameters);
            // Handle the event with the provided operation event

            this.socketSessionEmitService.SendOperationEvent((ISocketSession)session, new OperationEvent()
            {
                EventCode = "noModelEventFromServer",
                Parameters = operationEvent.Parameters
            }, sendParameters);
        }

    }

}
