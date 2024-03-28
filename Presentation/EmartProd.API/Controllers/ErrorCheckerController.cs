using EmartProd.API.Responses;
using EmartProd.Infrastructure.EmartContext;
using Microsoft.AspNetCore.Mvc;

namespace EmartProd.API.Controllers
{
    public class ErrorCheckerController : BaseAPIController
    {
        public EmartProdContext _context { get; }
       public ErrorCheckerController(EmartProdContext context)
       {
            this._context = context;
        
       } 

       [HttpGet("notfound")]
       public ActionResult GetNotFoundResponse()
       {
           var product = _context.Products.Find(42);
            if (product == null) return NotFound(new APIResponse(404));
           
           return Ok();
       }  

       [HttpGet("servererror")]
       public ActionResult GetServerErrorResponse()
       {
          var product = _context.Products.Find(42);
          var productToReturn = product.ToString();

          return Ok();
       }

       [HttpGet("badrequest")]
       public ActionResult GetBadRequestResponse()
       {
          return BadRequest(new APIResponse(400));
       }

       [HttpGet("badrequest/{id}")]
       public ActionResult GetBadRequestResForType(int id)
       {
          return Ok();
       }
    }
}