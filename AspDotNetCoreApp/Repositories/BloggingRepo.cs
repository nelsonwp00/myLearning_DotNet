using AspDotNetCoreApp.Data;
using Microsoft.EntityFrameworkCore;

namespace AspDotNetCoreApp.Repositories
{
    public class BloggingRepo
    {
        private readonly AdoDotnetExampleContext db;

        public BloggingRepo(AdoDotnetExampleContext db)
        {
            this.db = db;
        }

        public void Add(BlogDTO dto)
        {
            Blog blog = new Blog { Name = dto.Name, Url = dto.Url };
            db.Blogs.Add(blog);
            db.SaveChanges();
        }

        public BlogDTO? Get(int id)
        {
            Blog? blog = db.Blogs.AsNoTracking().FirstOrDefault(b => b.BlogId == id);
            if (blog == null)
                return null;
            return new BlogDTO(blog.Name, blog.Url);
        }

        public List<BlogDTO> GetAll() 
        {
            List<BlogDTO> list = db.Blogs.AsNoTracking().Select(b => new BlogDTO(b.Name, b.Url)).ToList();
            return list;
        }

        public void Update(int id) 
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
