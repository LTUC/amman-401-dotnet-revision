using Microsoft.EntityFrameworkCore;
using SoundLibrary.Data.Models;
using SoundLibrary.Data.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundLibrary.Data.Interfaces.Services
{
    public class PersonRepository : IPerson
    {
        private BlogsDbContext _context;

        public PersonRepository(BlogsDbContext context)
        {
            _context = context;
        }

        // On user creation, a blog should be created and associated, the blog will take a default name
        // that the user is able to edit after
        public async Task<PersonDTO> Create(NewPersonDTO newPersonDTO)
        {
            Blog blog = new Blog { Name = newPersonDTO.FirstName + "'s Blog" };
            Person person = new Person { FirstName = newPersonDTO.FirstName, LastName = newPersonDTO.LastName, Blog = blog };
            _context.Entry(person).State = EntityState.Added;
            _context.Entry(blog).State = EntityState.Added;
            await _context.SaveChangesAsync();
            PersonDTO personDTO = await GetPerson(person.Id);
            return personDTO;
        }

        public async Task Delete(int id)
        {
            Person person = await _context.Person.FindAsync(id);
            _context.Entry(person).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<PersonDTO> GetPerson(int id)
        {
            PersonDTO personDTO =  await _context.Person
                .Include(p => p.Blog).Select(p => new PersonDTO
                {
                    Id = p.Id, 
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    PersonEmbeddedBlogDTO = new PersonEmbeddedBlogDTO { Id = p.Blog.Id, Name = p.Blog.Name }
                })
                .FirstOrDefaultAsync(p => p.Id == id);

            return personDTO;
        }

        public async Task<List<PersonDTO>> GetPersons()
        {
            // one way to retrive related items is using include while querying
            // another is to run another query on the context getting the values that correspond to the person
            return await _context.Person
                .Include(p => p.Blog).Select(p => new PersonDTO
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    PersonEmbeddedBlogDTO = new PersonEmbeddedBlogDTO { Id = p.Blog.Id, Name = p.Blog.Name }
                })
                .ToListAsync();
        }

        public async Task<Person> UpdatePerson(int id, Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return person;
        }
    }
}
