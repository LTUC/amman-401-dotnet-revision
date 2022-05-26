
using SoundLibrary.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoundLibrary.Data.Interfaces
{
    public interface IGroup
    {
        // CREATE
        Task<Group> Create(Group group);

        // GET ALL
        Task<List<Group>> GetGroups();

        // GET ONE BY ID
        Task<Group> GetGroup(int id);

        // UPDATE
        Task<Group> UpdateGroup(int id, Group group);

        // DELETE
        Task Delete(int id);
        Task<Group> AddPersonToGroup(int groupId, int personId);
        Task RemovePersonFromGroup(int groupId, int personId);
    }
}
