using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace PRODUCTS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XperationController : ControllerBase
    {
        [HttpGet]
        [Route("Suma/{numA:int}/{numB:int}")]
        public IActionResult Suma(int numA, int numB)
        {
            int Sum = numA + numB;
            return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Resul = Sum });
        }
    }
}
