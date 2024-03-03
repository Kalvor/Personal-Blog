using Microsoft.AspNetCore.Mvc;

namespace blog_service.RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        public TestController()
        {
                
        }

        [HttpGet]
        public async Task<string> Test()
        {
            return await Task.FromResult("TEST");
        }
    }
}
