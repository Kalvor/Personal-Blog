using Microsoft.AspNetCore.Mvc;

namespace blog_service.RestApi.Controllers
{
    [ApiController]
    [Route("article")]
    public class ArticleController : ControllerBase
    {
        public ArticleController()
        {
                
        }

        [HttpGet]
        public async Task<string> Get()
        {
            return await Task.FromResult("TEST");
        }

        [HttpGet("{id}")]
        public async Task<string> Get([FromRoute]int id)
        {
            return await Task.FromResult("TEST");
        }

        [HttpPost]
        public async Task<string> Create([FromBody] string name)
        {
            return await Task.FromResult("TEST");
        }

        [HttpPut("{id}")]
        public async Task<string> Update([FromRoute] int id, [FromBody] string name)
        {
            return await Task.FromResult("TEST");
        }

        [HttpDelete("{id}")]
        public async Task<string> Delete([FromRoute] int id)
        {
            return await Task.FromResult("TEST");
        }

        [HttpPost("{articleId}/comment")]
        public async Task<string> CreateComment([FromRoute]int articleId, [FromBody]string comment)
        {
            return await Task.FromResult("TEST");
        }
    }
}
