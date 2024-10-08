using XmobiTea.Data.Converter.Rpc;
using XmobiTea.ProtonNet.Networking;
using XmobiTea.ProtonNet.Server.Handlers;
using XmobiTea.ProtonNet.Server.Handlers.Attributes;
using XmobiTea.ProtonNet.Server.Models;

namespace __Namespace__
{
    class __CodePrefix__EventModel
    {
        // Just demo field receive from client here, you can remove or replace with another.
        [StringDataMember(Code = "templateString")]
        public string TemplateString;

    }

    [AllowAnonymous]
    class __Template__EventHandler : EventHandler<__CodePrefix__EventModel>
    {
        public override string GetEventCode() => "__CodePrefix__";

        public override void Handle(__CodePrefix__EventModel eventModel, OperationEvent operationEvent, SendParameters sendParameters, IUserPeer userPeer, ISession session)
        {
            // Handle the event with the provided event model
            
        }

    }

}
