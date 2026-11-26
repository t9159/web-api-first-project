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
        ILogger<UsersController> _logger;

        IConfiguration _configuration;
        public UsersController(IUserService usersService, IStrongPasswordService strongPasswordService, IConfiguration configuration, ILogger<UsersController> logger)
        {
            _usersService = usersService;
            _strongPasswordService = strongPasswordService;
            _configuration = configuration;
            _logger = logger;
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
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
            int score = int.Parse(_configuration["StrongPasswordScore:Developer"]);
            if (_strongPasswordService.GetStrongPassword(user.Password).Score > (score!=null?score:4))
            {
                user = await _usersService.AddUser(user);
                _logger.LogInformation($"Added attempted with user name: {user.Email}, name: {user.FirstName} {user.LastName} ");
                return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
            }
            else
                return BadRequest();
        }

        [HttpPost("Login")]
        public async Task<ActionResult<User>> Post([FromBody] LoginUser loginUser)
        {
            var user = await _usersService.GetUser(loginUser);
            if (user == null)
                return NoContent();
            _logger.LogInformation($"Login attempted with user name: {loginUser.Email} ");
            return Ok(user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] User updateUserDetails)
        {
            if (_strongPasswordService.GetStrongPassword(updateUserDetails.Password).Score > 2)
            {
                await _usersService.UpdateUser(id, updateUserDetails);
                _logger.LogInformation($"Added attempted to user number {id}: email: {updateUserDetails.Email}, name: {updateUserDetails.FirstName} {updateUserDetails.LastName} ");
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
