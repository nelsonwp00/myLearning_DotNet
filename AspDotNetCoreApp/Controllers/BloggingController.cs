using AspDotNetCoreApp.Data;
using AspDotNetCoreApp.DataAccess;
using AspDotNetCoreApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspDotNetCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloggingController : ControllerBase
    {
        private readonly ILogger? Logger;
        private readonly BloggingRepo Repo;

        // Dependency Injection
        public BloggingController(AdoDotnetExampleContext db) 
        {
            Repo = new BloggingRepo(db);
        }

        [HttpGet]
        public IEnumerable<BlogDTO> Get()
        {
            return Repo.GetAll();
        }

        [HttpGet("{id}")]
        public BlogDTO Get(int id)
        {
            return Repo.Get(id);
        }

        [HttpPost]
        public HttpResponseMessage Add([FromBody] BlogDTO dto)
        {
            if (dto == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            Repo.Add(dto);

            return new HttpResponseMessage(HttpStatusCode.OK);

        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
