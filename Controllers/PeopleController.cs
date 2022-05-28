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
using SoundLibrary.Data.Models.DTO;

namespace SoundLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPerson _person;

        public PeopleController(IPerson person)
        {
            _person = person;
        }

        // GET: api/Persons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            var list = await _person.GetPersons();
            return Ok(list);
        }

        // GET: api/Persons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDTO>> GetPerson(int id)
        {
            PersonDTO personDTO = await _person.GetPerson(id);
            return Ok(personDTO);
        }

        // PUT: api/Persons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            var updatedPerson = await _person.UpdatePerson(id, person);

            return Ok(updatedPerson);
        }


        // Every person in the system should have a blog, so we will create a blog upon user
        // creation and associate it with that user, that's why adding a blog in the blogs controller
        // is not an option

        // POST: api/Persons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(NewPersonDTO newPersonDTO)
        {
            PersonDTO personDTO = await _person.Create(newPersonDTO);
            return CreatedAtAction("GetPerson", new { id = personDTO.Id }, personDTO);
        }

        // DELETE: api/Persons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            await _person.Delete(id);
            return NoContent();
        }
    }
}
