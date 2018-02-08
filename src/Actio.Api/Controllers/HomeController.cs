using Microsoft.AspNetCore.Mvc;

namespace Actio.Api.Controllers {
    [Route("")]
    public class HomeController : Controller {
        [HttpGet("")]
        public ActionResult Get(){
            return Content("Hello From Actio API");
        }
    }
}