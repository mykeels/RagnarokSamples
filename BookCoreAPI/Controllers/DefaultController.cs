using Microsoft.AspNetCore.Mvc;
namespace BookCoreAPI.Controllers {
    [Route("")]
    public class DefaultController: Controller {
        [HttpGet]
        public string Get()
        {
            return "Hello World";
        }
    }
}