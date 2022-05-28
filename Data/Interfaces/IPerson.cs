using SoundLibrary.Data.Models;
using SoundLibrary.Data.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoundLibrary.Data.Interfaces
{
    public interface IPerson
    {
        // CREATE
        Task<PersonDTO> Create(NewPersonDTO newPersonDTO);

        // GET ALL
        Task<List<PersonDTO>> GetPersons();

        // GET ONE BY ID
        Task<PersonDTO> GetPerson(int id);

        // UPDATE
        Task<Person> UpdatePerson(int id, Person person);

        // DELETE
        Task Delete(int id);
    }
}
