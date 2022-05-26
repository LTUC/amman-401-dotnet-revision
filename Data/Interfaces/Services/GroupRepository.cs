using Microsoft.EntityFrameworkCore;
using SoundLibrary.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundLibrary.Data.Interfaces.Services
{
    public class GroupRepository : IGroup
    {
        private BlogsDbContext _context;

        public GroupRepository(BlogsDbContext context)
        {
            _context = context;
        }
        public async Task<Group> Create(Group group)
        {
            _context.Entry(group).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return group;
        }

        public async Task Delete(int id)
        {
            Group group = await GetGroup(id);
            _context.Entry(group).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Group> GetGroup(int id)
        {
            return await _context.Group
                .Include(g => g.Persons)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<List<Group>> GetGroups()
        {
            // one way to retrive related items is using include while querying
            // another is to run another query on the context getting the values that correspond to the group
            return await _context.Group
                .Include(g => g.Persons)
                .ToListAsync();
        }

        public async Task<Group> UpdateGroup(int id, Group group)
        {
            _context.Entry(group).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return group;
        }


        public async Task<Group> AddPersonToGroup(int groupId, int personId)
        {
            Group group = await GetGroup(groupId);
            Person person = await _context.Person
                .FirstOrDefaultAsync(p => p.Id == personId);
            group.Persons.Add(person);
            await _context.SaveChangesAsync();
            return group;
        }

        public async Task RemovePersonFromGroup(int groupId, int personId)
        {
            Group group = await GetGroup(groupId);
            Person person;
            try
            {
                person = group.Persons.Single(p => p.Id == personId);
            } 
            catch (ArgumentNullException e)
            {
                throw e;
            }

            group.Persons.Remove(person);
            await _context.SaveChangesAsync();
        }
    }
}
