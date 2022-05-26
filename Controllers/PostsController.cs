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
    public class PostsController : ControllerBase
    {
        private readonly IPost _post;

        
        public PostsController(IPost post)
        {
            _post = post;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            var list = await _post.GetPosts();
            return Ok(list);
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            Post post = await _post.GetPost(id);
            return Ok(post);
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }

            var updatedPost = await _post.UpdatePost(id, post);

            return Ok(updatedPost);
        }

        // We are deleting this because we are not adding  the post directly through controller, it should be just added through blogs
        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Post>> PostPost(Post post)
        //{
        //    await _post.Create(post);
        //    return CreatedAtAction("GetPost", new { id = post.Id }, post);
        //}

        // This shouldn't exist, as the delete is used from within the blog - to be discussed
        // DELETE: api/Posts/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePost(int id)
        //{
        //    await _post.Delete(id);
        //    return NoContent();
        //}
    }
}
