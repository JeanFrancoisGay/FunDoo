using FunDoo_API.DAL;
using FunDoo_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FunDoo_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            try
            {
                return "Success";
            }
            catch
            {
                return StatusCode(500, "Failure!");
            }
        }
    }
}
