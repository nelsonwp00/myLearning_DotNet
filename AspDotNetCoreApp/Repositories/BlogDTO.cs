namespace AspDotNetCoreApp.Repositories
{
    public class BlogDTO
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public BlogDTO() { }

        public BlogDTO(string Name, string Url) 
        {
            this.Name = Name;
            this.Url = Url;
        }
    }
}
