using Microsoft.EntityFrameworkCore;
using SoundLibrary.Data.Models;

namespace SoundLibrary.Data
{
    public class BlogsDbContext : DbContext
    {
        public BlogsDbContext(DbContextOptions options) : base(options)
        {
        }
        

        public DbSet<Person> Person { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<SoundLibrary.Data.Models.Group> Group { get; set; }

    }
}
