using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogStarWars.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogStarWars.Data
{
    public class BlogStarWarsContext : DbContext
    {
        public BlogStarWarsContext(DbContextOptions<BlogStarWarsContext> options) : base(options)
        {
        }

        public DbSet<Post> Post { get; set; }
    }
}
