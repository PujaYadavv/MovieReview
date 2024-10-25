using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieReview.Server.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("error")]
        public async Task<IActionResult> HandleError()
        {
            if (HttpContext != null)
            {
                IExceptionHandlerPathFeature feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
                if (feature != null)
                {
                    return Problem(detail: feature.Error.Message);
                }
            }
            return Problem();
        }
    }
}
