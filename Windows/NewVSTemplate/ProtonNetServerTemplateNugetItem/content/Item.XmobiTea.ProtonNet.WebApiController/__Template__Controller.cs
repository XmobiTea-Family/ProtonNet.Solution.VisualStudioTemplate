using XmobiTea.ProtonNet.Server.WebApi.Controllers;
using XmobiTea.ProtonNet.Server.WebApi.Controllers.Attribute;
using XmobiTea.ProtonNetCommon;
using XmobiTea.ProtonNetCommon.Extensions;

namespace __Namespace__
{
    [Route("/__CodePrefix__")]
    class __Template__Controller : WebApiController
    {
        [HttpGet("hello")]
        private HttpResponse Hello()
        {
            return this.Response().MakeGetResponse("How are you?");
        }

    }

}
