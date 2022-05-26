using Microsoft.EntityFrameworkCore;
using SoundLibrary.Data.Models;
using System.Collections.Generic;
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
        public async Task<Person> Create(Person person)
        {
            Blog blog = new Blog { Name = person.FirstName + "'s Blog" };
            person.Blog = blog;
            _context.Entry(person).State = EntityState.Added;
            _context.Entry(blog).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task Delete(int id)
        {
            Person person = await GetPerson(id);
            _context.Entry(person).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Person> GetPerson(int id)
        {
            return await _context.Person
                .Include(p => p.Blog)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Person>> GetPersons()
        {
            // one way to retrive related items is using include while querying
            // another is to run another query on the context getting the values that correspond to the person
            return await _context.Person
                .Include(p => p.Blog)
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
