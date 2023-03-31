using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AspDotNetCoreApp.Data;

public partial class AdoDotnetExampleContext : DbContext
{
    public AdoDotnetExampleContext()
    {
    }

    public AdoDotnetExampleContext(DbContextOptions<AdoDotnetExampleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-005HGM9;Database=ado_dotnet_example;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasKey(e => e.BlogId).HasName("PK_dbo.Blogs");

            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Url).HasMaxLength(200);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK_dbo.Posts");

            entity.Property(e => e.Content).HasColumnType("ntext");
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.Blog).WithMany(p => p.Posts)
                .HasForeignKey(d => d.BlogId)
                .HasConstraintName("FK_dbo.Posts_dbo.Blogs_BlogId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public override void Dispose()
    {
        base.Dispose();
    }
}
