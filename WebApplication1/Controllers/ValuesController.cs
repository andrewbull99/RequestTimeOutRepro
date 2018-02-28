using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "Hello World";
        }

        // POST api/values
        [HttpPost("upload")]
        public void Post()
        {
            Response.Redirect("http://www.wikipedia.org");
        }
    }
}
