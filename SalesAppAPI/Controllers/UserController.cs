using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesAppAPI.Data;
using SalesAppAPI.Interfaces.Users;
using SalesAppAPI.Models;

namespace SalesAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _IUsers;

        public UserController(IUserRepository iUsers)
        {
            _IUsers = iUsers;
        }


        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _IUsers.GetUsers();

        }


        [HttpGet("id")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _IUsers.GetUser(id);
            
            return user == null ? NotFound() : Ok(user);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(User user)
        {
            try
            {
                await _IUsers.AddUser(user);
                return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
            }
            catch (Exception)
            {

                throw;
            }

       

        }

        [HttpPost("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, User user)
        {
            if (id != user.Id) return BadRequest();
           await _IUsers.UpdateUser(user);  
            return NoContent();

        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _IUsers.DeleteUser(id);

            if (user == null)
            {
                return NotFound($"Employee with Id = {id} not found");
            }

            return await employeeRepository.DeleteEmployee(id);

            return NoContent();
        }


    }

}
