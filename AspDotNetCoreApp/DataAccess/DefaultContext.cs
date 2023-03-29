using AspDotNetCoreApp.DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace AspDotNetCoreApp.DataAccess
{
    public class DefaultContext : DbContext
    {
        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options) { }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
