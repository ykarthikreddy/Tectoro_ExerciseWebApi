using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspcoreTestApp.Models;

namespace AspcoreTestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserContext _context;

        public UsersController(UserContext context)
        {
            _context = context;
        }

        // GET: api/Users/Getusers
        [HttpGet(Name = "Get Users")]
        [Route("Getusers")]
        public IEnumerable<Users> Getusers()
        {
            return _context.users;
        }

        // GET: api/Users/GetManagersAssociatedClients
        [HttpGet(Name = "Get Managers list")]
        [Route("GetManagersAssociatedClients")]
        public object GetManagersAssociatedClients()
        {
           //return _context.users.Join(_context.users, e => e.UserID, s => s.MgrId, 
           //                 (e, s) => new 
           //                 {
           //                     UserID =e.UserID,
           //                     UserName = e.UserName,
           //                     Email = e.Email,
           //                     FirstName = e.FirstName,
           //                     LastName = e.LastName,
           //                     Level = e.Level,
           //                     Position =e.Position,
           //                     Clients = (_context.users.Where(x => x.MgrId == s.MgrId).ToList())
           //                 }).Distinct().ToList();


            return _context.users.GroupBy(x => x.UserID).Select(e => new
            {
                UserID = e.First().UserID,
                UserName = e.First().UserName,
                Email = e.First().Email,
                FirstName = e.First().FirstName,
                LastName = e.First().LastName,
                Level = e.First().Level,
                Position = e.First().Position,
                Clients = (_context.users.Where(x => x.MgrId == e.First().UserID).ToList())
            }).Where(y => y.Position !=null).Distinct().ToList();


            // IEnumerable<UsersViewModel> mglist = mgrlist;GroupBy(x => x.UserID)
            // return mglist;
        }

        // GET: api/Users/GetClientsWithManagers
        [HttpGet(Name = "Get Clients list")]
        [Route("GetClientsWithManagers")]
        public object GetClientsWithManagers()
        {
            return _context.users.Join(_context.users, e => e.MgrId, s => s.UserID,
                             (e, s) => new 
                             {
                                 UserID = e.UserID,
                                 UserName = e.UserName,
                                 Email = e.Email,
                                 FirstName = e.FirstName,
                                 LastName = e.LastName,
                                 Level =e.Level,
                                 MgrId =e.MgrId,
                                 Manager = (_context.users.Where(x => x.UserID == e.MgrId).ToList())
                             }).Distinct().ToList();
        }

        // GET: api/Users/GetClientsForManagerById/{id}
        [HttpGet(Name = "Get Clients list for Manager id")]
        [Route("GetClientsForManagerById/{id}")]
        public object GetClientsForManagerById(int id)
        {
            return _context.users.Where(x => x.MgrId == id).ToList();
                                
                        
        }

        // GET: api/Users/GetClientsForManagerByName/{UserName}
        [HttpGet(Name = "Get Clients list for Manager Name")]
        [Route("GetClientsForManagerByName/{UserName}")]
        public object GetClientsForManagerById(string UserName)
        {
            int id = -1 ;
            var users = _context.users.FirstOrDefault(x => x.UserName == UserName);
            if(users != null)
            {
                id = ((Users)users).UserID;
            }
           
            return _context.users.Where(x => x.MgrId == id).ToList();


        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = await _context.users.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers([FromRoute] int id, [FromBody] Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users.UserID)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUsers([FromBody] Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(UserNameExists(users.UserName))
            {
                return BadRequest();
            }

            _context.users.Add(users);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsers", new { id = users.UserID }, users);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = await _context.users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.users.Remove(users);
            await _context.SaveChangesAsync();

            return Ok(users);
        }

        private bool UsersExists(int id)
        {
            return _context.users.Any(e => e.UserID == id);
        }
        private bool UserNameExists(string UserName)
        {
            return _context.users.Any(e => e.UserName == UserName);
        }
    }
}