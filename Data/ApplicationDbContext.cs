using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace js.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
            public DbSet<Link> Link { get; set; }
            public DbSet<Comment> Comment { get; set; }
            public DbSet<Task> Task { get; set; }
            public DbSet<Bucket> Bucket { get; set; }
            public DbSet<Progress> Progress { get; set; }

    }
}
