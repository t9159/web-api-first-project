using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //fix: It is a fixed value
        readonly string filePath = "DataUsers.txt";
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Ruti", "Tamar", "Esti" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        //Why isn't it implemented? Fix it
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        { 
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.Id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
            return CreatedAtAction(nameof(Get), new {Id = user.Id}, user);
        }

        [HttpPost("Login")]
        public ActionResult<User> Post([FromBody] LoginUser loginUser)
        {
            if (!System.IO.File.Exists(filePath))
            {
                return BadRequest();
            }
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Email == loginUser.Email && user.Password == loginUser.Password)
                        return Ok(user);
                }
            }
            return BadRequest();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User updateUserDetails)
        {
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Id == id)
                    {
                        textToReplace = currentUserInFile;
                        //fix: Found- break
                        break;
                    }
                }
            }
            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(updateUserDetails));
                System.IO.File.WriteAllText(filePath, text);
                //fix: instead of return Ok()
                return NoContent()
            }
            //fix: in a case of user not found
            return NotFound();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
