using XmobiTea.ProtonNet.Networking;
using XmobiTea.ProtonNet.Server.Handlers;
using XmobiTea.ProtonNet.Server.Handlers.Attributes;
using XmobiTea.ProtonNet.Server.Models;

namespace __Namespace__
{
    [AllowAnonymous]
    class __Template__EventHandler : EventHandler
    {
        public override string GetEventCode() => "__CodePrefix__";
        
        public override void Handle(OperationEvent operationEvent, SendParameters sendParameters, IUserPeer userPeer, ISession session)
        {
            // Handle the event with the provided operation event
            
        }

    }

}
