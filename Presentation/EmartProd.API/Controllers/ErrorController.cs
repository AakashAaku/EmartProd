using EmartProd.API.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EmartProd.API.Controllers
{
    [ApiExplorerSettings(IgnoreApi =true)]
    [Route("error/{code}")]
    public class ErrorController:BaseAPIController
    {
        public IActionResult Error(int code)
        {
            return new ObjectResult(new APIResponse(code));
        }
    }
}