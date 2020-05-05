using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ROB.Web.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }

        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, not found";
                    logger.LogWarning($" 404 Error Occured. The path {statusCodeResult.OriginalPath} " +
                        $"and QueryString = {statusCodeResult.OriginalQueryString}");
                    break;
                default:
                    break;
            }

            // could email these errors to a dev email or store in database... maybe

            return View("NotFound");
        }

        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            ViewBag.ExceptionPath = exceptionDetails.Path;
            ViewBag.ExceptionMessage = exceptionDetails.Error.Message;
            ViewBag.Stacktrace = exceptionDetails.Error.StackTrace;

            logger.LogError($"The path {exceptionDetails.Path} threw an exception {exceptionDetails.Error}");

            // THIS ALL NEEDS TO BE LOGGED TO THE DATABASE & EMAILED

            return View("Error");
        }
    }
}