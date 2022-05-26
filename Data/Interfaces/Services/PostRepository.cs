using Microsoft.EntityFrameworkCore;
using SoundLibrary.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoundLibrary.Data.Interfaces.Services
{
    public class PostRepository : IPost
    {
        private BlogsDbContext _context;

        public PostRepository(BlogsDbContext context)
        {
            _context = context;
        }

        // We are deleting this because we are not adding  the post directly through controller, it should be just added through blogs
        //public async Task<Post> Create(Post post)
        //{
        //    _context.Entry(post).State = EntityState.Added;
        //    await _context.SaveChangesAsync();
        //    return post;
        //}

        // This shouldn't exist, as the delete is used from within the blog - to be discussed
        //public async Task Delete(int id)
        //{
        //    Post post = await GetPost(id);
        //    _context.Entry(post).State = EntityState.Deleted;
        //    await _context.SaveChangesAsync();
        //}

        public async Task<Post> GetPost(int id)
        {
            return await _context.Post
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Post>> GetPosts()
        { 
            return await _context.Post
                .ToListAsync();
        }

        public async Task<Post> UpdatePost(int id, Post post)
        {
            _context.Entry(post).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return post;
        }
    }
}
