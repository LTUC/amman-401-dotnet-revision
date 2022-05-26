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

namespace SoundLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroup _group;

        public GroupsController(IGroup group)
        {
            _group = group;
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroups()
        {
            var list = await _group.GetGroups();
            return Ok(list);
        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> GetGroup(int id)
        {
            Group group = await _group.GetGroup(id);
            return Ok(group);
        }

        // PUT: api/Groups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroup(int id, Group group)
        {
            if (id != group.Id)
            {
                return BadRequest();
            }

            var updatedGroup = await _group.UpdateGroup(id, group);

            return Ok(updatedGroup);
        }

        // POST: api/Groups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Group>> PostGroup(Group group)
        {
            await _group.Create(group);
            return CreatedAtAction("GetGroup", new { id = group.Id }, group);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            await _group.Delete(id);
            return NoContent();
        }

        [HttpPut("{groupId}/add/{personId}")]
        public async Task<IActionResult> AddPersonToGroup(int groupId, int personId)
        {
            Group group = await _group.AddPersonToGroup(groupId, personId);
            return Ok(group);
        }

        [HttpPut("{groupId}/remove/{personId}")]
        public async Task<IActionResult> RemovePersonFromGroup(int groupId, int personId)
        {
            try
            {
                await _group.RemovePersonFromGroup(groupId, personId);
            } 
            catch(Exception e)
            {
                return BadRequest();
            }
            return NoContent();
        }


    }
}
