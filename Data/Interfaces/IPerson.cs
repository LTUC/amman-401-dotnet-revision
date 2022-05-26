using SoundLibrary.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoundLibrary.Data.Interfaces
{
    public interface IPerson
    {
        // CREATE
        Task<Person> Create(Person person);

        // GET ALL
        Task<List<Person>> GetPersons();

        // GET ONE BY ID
        Task<Person> GetPerson(int id);

        // UPDATE
        Task<Person> UpdatePerson(int id, Person person);

        // DELETE
        Task Delete(int id);
    }
}
