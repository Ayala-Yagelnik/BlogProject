using Microsoft.AspNetCore.Mvc;
using Posts_project.Entities;
using Posts_project.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Posts_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService data=new UserService();
        // GET: api/<UserController>
        [HttpGet]
        public ActionResult Get()
        {
            var users = data.Get();
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var user = data.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            bool success=data.AddUser(user);
            if (success)
            {
                return Ok(true);
            }
            return NotFound();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User user)
        {
            bool success = data.Update(id, user);
            if (success)
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool success = data.Delete(id);
            if (success)
                return Ok(true);
            return NotFound();
        }
    }
}
