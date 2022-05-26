using SoundLibrary.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoundLibrary.Data.Interfaces
{
    public interface IPost
    {
        // We are deleting this because we are not adding  the post directly through controller, it should be just added through blogs
        // CREATE
        //Task<Post> Create(Post post);

        // GET ALL
        Task<List<Post>> GetPosts();

        // GET ONE BY ID
        Task<Post> GetPost(int id);

        // UPDATE
        Task<Post> UpdatePost(int id, Post post);

        // This shouldn't exist, as the delete is used from within the blog - to be discussed
        // DELETE
       // Task Delete(int id);
    }
}
