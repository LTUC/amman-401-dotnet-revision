using System.Collections.Generic;

namespace SoundLibrary.Data.Models
{
    public class Group : AbstractModel
    {
        public string Name{ get; set; }

        // the relatoinship between a group and a person is a many to many relationship
        // represented by adding a list of person (navigation property) to Group, and adding a list of group (navigation property) to Person
        public List<Person> Persons{ get; set; }
    }
}
