using SoundLibrary.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoundLibrary.Data.Interfaces
{
    public interface IBlog
    {
        // This shouldn't exist as creating a blog is done when we create a person, or through a person (add blog to person)
        // CREATE
        /*Task<Blog> Create(Blog blog);*/

        // GET ALL
        Task<List<Blog>> GetBlogs();

        // GET ONE BY ID
        Task<Blog> GetBlog(int id);

        // UPDATE
        Task<Blog> UpdateBlog(int id, Blog blog);

        // This shouldn't exist
        // DELETE
        //Task Delete(int id);

        Task<Post> AddPostToBlog(int blogId, Post post);
        Task DeletePostFromBlog(int blogId, int postId);
        Task<List<Post>> GetBlogPosts(int blogId);
    }
}
