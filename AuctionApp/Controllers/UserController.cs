using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataMapper.PostgresDAO;
using ServiceLayer;
using DomainModel.Entity;

namespace AuctionApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: api/UserAccounts
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUserAccount()
        {
            var users = userService.GetAll();
            if (users == null)
            {
                return NotFound();
            }

            return users.ToList();
        }

        //// GET: api/UserAccounts/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<User>> GetUserAccount(int id)
        //{
        //    if (_context.Users == null)
        //    {
        //        return NotFound();
        //    }
        //    var userAccount = await _context.Users.FindAsync(id);

        //    if (userAccount == null)
        //    {
        //        return NotFound();
        //    }

        //    return userAccount;
        //}

        //// PUT: api/UserAccounts/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUserAccount(int id, User userAccount)
        //{
        //    if (id != userAccount.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(userAccount).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserAccountExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/UserAccounts
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<User>> PostUserAccount(User userAccount)
        //{
        //    if (_context.Users == null)
        //    {
        //        return Problem("Entity set 'AuctionAppContext.UserAccount'  is null.");
        //    }
        //    _context.Users.Add(userAccount);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetUserAccount", new { id = userAccount.Id }, userAccount);
        //}

        //// DELETE: api/UserAccounts/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUserAccount(int id)
        //{
        //    if (_context.Users == null)
        //    {
        //        return NotFound();
        //    }
        //    var userAccount = await _context.Users.FindAsync(id);
        //    if (userAccount == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Users.Remove(userAccount);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool UserAccountExists(int id)
        //{
        //    return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
