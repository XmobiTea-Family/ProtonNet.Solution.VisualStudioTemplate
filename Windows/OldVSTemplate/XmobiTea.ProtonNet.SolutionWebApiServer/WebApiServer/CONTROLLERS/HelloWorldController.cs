using XmobiTea.Bean.Attributes;
using XmobiTea.ProtonNet.Server.WebApi.Controllers;
using XmobiTea.ProtonNet.Server.WebApi.Controllers.Attribute;
using XmobiTea.ProtonNetCommon;
using XmobiTea.ProtonNetCommon.Extensions;
using XmobiTea.ProtonNetCommon.Types;

namespace $safeprojectname$.Controllers
{
    /// <summary>
    /// Handles requests routed to "/helloworld".
    /// </summary>
    [Route("/helloworld")]
    class HelloWorldController : WebApiController
    {
        /// <summary>
        /// AutoBind the application
        /// </summary>
        [AutoBind]
        private Application application { get; set; }

        /// <summary>
        /// Returns a simple greeting message.
        /// Route: GET /helloworld/hello
        /// </summary>
        /// <returns>Returns a string response with a greeting.</returns>
        [HttpGet("hello")]
        private HttpResponse Hello() => this.Response().MakeGetResponse("How are you");

        /// <summary>
        /// Responds with a simple status check.
        /// Route: GET /helloworld/ping
        /// </summary>
        /// <returns>Returns an OK status response.</returns>
        [HttpGet("ping")]
        private HttpResponse Ping() => this.Response().MakeOkResponse(StatusCode.OK);

        /// <summary>
        /// Retrieves the current timestamp.
        /// Route: GET /helloworld/getts
        /// </summary>
        /// <returns>Returns the current date and time as a string.</returns>
        [HttpGet("getUTCDate")]
        private HttpResponse GetUTCDate() => this.Response().MakeGetResponse(System.DateTimeOffset.Now.ToString());

        /// <summary>
        /// Retrieves the current timestamp.
        /// Route: GET /helloworld/getts
        /// </summary>
        /// <returns>Returns the current date and time as a string.</returns>
        [HttpGet("debugApplication")]
        private HttpResponse DebugApplication() => this.Response().MakeGetResponse(this.application.ToString());

    }

}
