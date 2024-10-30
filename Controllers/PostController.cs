using Microsoft.AspNetCore.Mvc;
using Posts_project.Entities;
using Posts_project.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Posts_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        PostService data = new PostService();
        // GET: api/<PostController>
        [HttpGet]
        public ActionResult Get()
        {
            var posts = data.Get();
            if (posts == null)
            {
                return NotFound();
            }
            return Ok(posts);
        }

        // GET api/<PostController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var post = data.GetById(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        // POST api/<PostController>
        [HttpPost]
        public ActionResult Post([FromBody] Post post)
        {
            bool success = data.AddPost(post);
            if (success)
            {
                return Ok(true);
            }
            return NotFound();
        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Post post)
        {
            bool success = data.Update(id, post);
            if (success)
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<PostController>/5
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
