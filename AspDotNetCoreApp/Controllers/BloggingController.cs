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
        public BloggingController(DefaultContext db) 
        {
            Repo = new BloggingRepo(db);
        }

        // GET: api/<BloggingController>
        [HttpGet]
        public IEnumerable<BlogDTO> Get()
        {
            return Repo.GetAll();
        }

        // GET api/<BloggingController>/5
        [HttpGet("{id}")]
        public BlogDTO Get(int id)
        {
            return Repo.Get(id);
        }

        // POST api/<BloggingController>
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

        // PUT api/<BloggingController>/5
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BloggingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
