using System.Collections.Generic;

namespace SoundLibrary.Data.Models
{
    // Entity createion steps:
    // 1- Create the model class
    // 2- Add DbSet to DbContext for that model
    // 3- Add-Migration
    // 4- Update-Database
    // 5- Add Controller 
    // 6- Add interface
    // 7- Add service (repository)

    public class Person : AbstractModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // One to One relationship with the blog
        public Blog Blog { get; set; }

        // the relatoinship between a group and a person is a many to many relationship
        // represented by adding a list of person (navigation property) to Group, and adding a list of group (navigation property) to Person
        public List<Group> Groups { get; set; }
    }
}
