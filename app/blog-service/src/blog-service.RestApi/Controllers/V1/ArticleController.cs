using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace blog_service.RestApi.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ArticleController : ControllerBase
    {
        public ArticleController()
        {

        }

        [MapToApiVersion("1.0")]
        [HttpGet]
        public async Task<string> Get()
        {
            return await Task.FromResult("TEST");
        }

        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
        public async Task<string> Get([FromRoute] int id)
        {
            return await Task.FromResult("TEST");
        }

        [MapToApiVersion("1.0")]
        [HttpPost]
        public async Task<string> Create([FromBody] string name)
        {
            return await Task.FromResult("TEST");
        }

        [MapToApiVersion("1.0")]
        [HttpPut("{id}")]
        public async Task<string> Update([FromRoute] int id, [FromBody] string name)
        {
            return await Task.FromResult("TEST");
        }

        [MapToApiVersion("1.0")]
        [HttpDelete("{id}")]
        public async Task<string> Delete([FromRoute] int id)
        {
            return await Task.FromResult("TEST");
        }

        [MapToApiVersion("1.0")]
        [HttpPost("{articleId}/comment")]
        public async Task<string> CreateComment([FromRoute] int articleId, [FromBody] string comment)
        {
            return await Task.FromResult("TEST");
        }
    }
}
