using XmobiTea.ProtonNet.Server.WebApi.Controllers;
using XmobiTea.ProtonNet.Server.WebApi.Controllers.Attribute;
using XmobiTea.ProtonNet.Server.WebApi.Models;
using XmobiTea.ProtonNetCommon;

namespace $safeprojectname$.Controllers
{
    [Route("/")]
    internal class IndexController : WebApiController
    {
        [HttpGet("")]
        private HttpResponse Index()
        {
            return this.View("Index", "_Layout", new ViewData()
                .SetData("Title", "Proton WebApiServer"));
        }

    }

}
