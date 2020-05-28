using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class ProductsController : Controller
    {
        [HttpGet]
        public IActionResult List()
        {
            return Ok();
        }
    }
}