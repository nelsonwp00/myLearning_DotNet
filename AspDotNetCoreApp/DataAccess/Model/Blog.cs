using DotNetFrameworkApp.Data;

namespace AspDotNetCoreApp.DataAccess.Model
{
    public class Blog
    {
        public int BlogId { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
