using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoundLibrary.Data;
using SoundLibrary.Data.Interfaces;
using SoundLibrary.Data.Models;

namespace SoundLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlog _blog;

        public BlogsController(IBlog blog)
        {
            _blog = blog;
        }

        // GET: api/Blogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blog>>> GetBlogs()
        {
            var list = await _blog.GetBlogs();
            return Ok(list);
        }

        // GET: api/Blogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetBlog(int id)
        {
            Blog blog = await _blog.GetBlog(id);
            return Ok(blog);
        }

        // PUT: api/Blogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlog(int id, Blog blog)
        {
            if (id != blog.Id)
            {
                return BadRequest();
            }

            var updatedBlog = await _blog.UpdateBlog(id, blog);

            return Ok(updatedBlog);
        }

        // This shouldn't exist as creating a blog is done when we create a person, or through a person (add blog to person)
        // POST: api/Blogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Blog>> PostBlog(Blog blog)
        //{
        //    await _blog.Create(blog);
        //    return CreatedAtAction("GetBlog", new { id = blog.Id }, blog);
        //}

        // This shouldn't exist as deleting a blog should be done through a person - not implemented - to be discussed
        // DELETE: api/Blogs/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteBlog(int id)
        //{
        //    await _blog.Delete(id);
        //    return NoContent();
        //}

        [HttpPost("{id}/posts")]
        public async Task<ActionResult<Post>> AddPostToBlog(int id, Post post)
        {
            await _blog.AddPostToBlog(id, post);
            return Ok(post);
        }

        [HttpDelete("{blogId}/posts/{postId}")]
        public async Task<IActionResult> DeletePostFromBlog(int blogId, int postId)
        {
            await _blog.DeletePostFromBlog(blogId, postId);
            return NoContent();
        }

        [HttpGet("{blogId}/posts")]
        public async Task<ActionResult<IEnumerable<Blog>>> GetBlogPosts(int blogId)
        {
            List<Post> posts = await _blog.GetBlogPosts(blogId);
            return Ok(posts);
        }

    }
}
