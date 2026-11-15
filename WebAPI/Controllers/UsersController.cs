using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Services;
using Entities;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _usersService;
        IStrongPasswordService _strongPasswordService;
        public UsersController(IUserService usersService, IStrongPasswordService strongPasswordService)
        {
            _usersService=usersService;
            _strongPasswordService = strongPasswordService;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Ruti", "Tamar", "Esti" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            //The assignment asks GET by id to read the user with this id from the file and return it (or NotFound / NoContent): how would you find the right line?
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
            if (_strongPasswordService.GetStrongPassword(user.Password).Score > 2)
            {
                user = await _usersService.AddUser(user);
                return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
            }
            else
                return BadRequest();
        }

        [HttpPost("Login")]
        public ActionResult<User> Post([FromBody] LoginUser loginUser)
        {
            var user = _usersService.GetUser(loginUser);
            if(user == null) 
                //The assignment asks a wrong login to return 204 NoContent: what would you change NotFound() to?
                return NotFound();
            return Ok(user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] User updateUserDetails)
        {
            if (_strongPasswordService.GetStrongPassword(updateUserDetails.Password).Score > 2)
            {
                await _usersService.UpdateUser(id, updateUserDetails);
                return Ok();
            }
            return BadRequest();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
