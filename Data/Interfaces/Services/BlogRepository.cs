using Microsoft.EntityFrameworkCore;
using SoundLibrary.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundLibrary.Data.Interfaces.Services
{
    public class BlogRepository : IBlog
    {
        private BlogsDbContext _context;

        public BlogRepository(BlogsDbContext context)
        {
            _context = context;
        }

        // This shouldn't exist as creating a blog is done when we create a person, or through a person (add blog to person)
        //public async Task<Blog> Create(Blog blog)
        //{
        //    _context.Entry(blog).State = EntityState.Added;
        //    await _context.SaveChangesAsync();
        //    return blog;
        //}

        // This shouldn't exist
        //public async Task Delete(int id)
        //{
        //    Blog blog = await GetBlog(id);
        //    _context.Entry(blog).State = EntityState.Deleted;
        //    await _context.SaveChangesAsync();
        //}

        public async Task<Blog> GetBlog(int id)
        {
            return await _context.Blog
                .Include(b => b.Posts)
                .Include(b => b.Perosn)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<Blog>> GetBlogs()
        {
            // one way to retrive related items is using include while querying
            // another is to run another query on the context getting the values that correspond to the blog
            return await _context.Blog
                .Include(b => b.Posts)
                .Include(b => b.Perosn)
                .ToListAsync();
        }

        public async Task<Blog> UpdateBlog(int id, Blog blog)
        {
            _context.Entry(blog).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return blog;
        }

        public async Task<Post> AddPostToBlog(int blogId,Post post)
        {
            Blog blog = await GetBlog(blogId);
            blog.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task DeletePostFromBlog(int blogId, int postId)
        {
            Blog blog = await GetBlog(blogId);
            blog.Posts.Remove(blog.Posts.Single(i => i.Id == postId));
            await _context.SaveChangesAsync();
        }

        public async Task<List<Post>> GetBlogPosts(int blogId)
        {
            Blog blog = await GetBlog(blogId);
            List<Post> posts = blog.Posts;
            return posts;
        }



    }
}
