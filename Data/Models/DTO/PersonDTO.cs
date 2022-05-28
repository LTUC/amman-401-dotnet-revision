namespace SoundLibrary.Data.Models.DTO
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public PersonEmbeddedBlogDTO PersonEmbeddedBlogDTO { get; set; }
    }
}
