using XmobiTea.ProtonNet.Server.WebApi.Controllers;
using XmobiTea.ProtonNet.Server.WebApi.Controllers.Attribute;
using XmobiTea.ProtonNetCommon;
using XmobiTea.ProtonNetCommon.Extensions;

namespace $rootnamespace$
{
    [Route("/$fileinputname$")]
    class $safeitemname$ : WebApiController
    {
        [HttpGet("hello")]
        private HttpResponse Hello()
        {
            return this.Response().MakeGetResponse("How are you?");
        }

    }

}
