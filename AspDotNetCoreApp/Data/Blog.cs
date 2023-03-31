using System;
using System.Collections.Generic;

namespace AspDotNetCoreApp.Data;

public partial class Blog
{
    public int BlogId { get; set; }

    public string? Name { get; set; }

    public string? Url { get; set; }

    public virtual ICollection<Post> Posts { get; } = new List<Post>();
}
