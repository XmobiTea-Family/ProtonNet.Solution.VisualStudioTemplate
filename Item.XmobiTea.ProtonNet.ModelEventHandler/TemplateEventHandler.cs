using XmobiTea.Data.Converter.Rpc;
using XmobiTea.ProtonNet.Networking;
using XmobiTea.ProtonNet.Server.Handlers;
using XmobiTea.ProtonNet.Server.Handlers.Attributes;
using XmobiTea.ProtonNet.Server.Models;

namespace $rootnamespace$
{
    class $fileinputname$EventModel
    {
        [StringDataMember(Code = "templateString")]
        public string TemplateString;

    }

    [AllowAnonymous]
    class $safeitemname$ : EventHandler<$fileinputname$EventModel>
    {
        public override string GetEventCode() => "$fileinputname$";

        public override void Handle($fileinputname$EventModel eventModel, OperationEvent operationEvent, SendParameters sendParameters, IUserPeer userPeer, ISession session)
        {
            // Handle the event with the provided operation event
            
        }

    }

}
