using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArticleManagement.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WestController : ControllerBase
    {
        [HttpGet]
        public string Get() => "Hello Auth. Content";

    }
}