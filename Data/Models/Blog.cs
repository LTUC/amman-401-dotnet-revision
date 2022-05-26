using System.Collections.Generic;

namespace SoundLibrary.Data.Models
{
    public class Blog : AbstractModel
    {
        public string Name { get; set; }

        // 1 way of presenting a relationship is to include both the foreign key and the reference property
        // this will be a one to one relationship with the Person entity
        public int PersonId { get; set; }
        public Person Perosn { get; set; }

        // The blog has many posts (one to many relationship), many ways can be used to represent this relationship
        // 1- Inlcude a list of posts (navigation property) in the Blog ONLY
        // 2- Include a list of posts (navigation property) in the blog and a reference to Blog (navigation property) in the post 
        // 3- Include a list of posts (navigation property) in the blog and a reference to Blog (navigation property) in the post and a foreig key referenct to blog in the post
        // In this example, we are implementing way number 1
        public List<Post> Posts { get; set; }


    }
}
