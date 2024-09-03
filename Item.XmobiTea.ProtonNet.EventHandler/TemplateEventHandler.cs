using XmobiTea.ProtonNet.Networking;
using XmobiTea.ProtonNet.Server.Handlers;
using XmobiTea.ProtonNet.Server.Handlers.Attributes;
using XmobiTea.ProtonNet.Server.Models;

namespace $rootnamespace$
{
    [AllowAnonymous]
    class $safeitemname$ : EventHandler
    {
        public override string GetEventCode() => "$fileinputname$";
        
        public override void Handle(OperationEvent operationEvent, SendParameters sendParameters, IUserPeer userPeer, ISession session)
        {
            // Handle the event with the provided operation event
            
        }

    }

}
