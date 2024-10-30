using Microsoft.AspNetCore.Mvc;
using Posts_project.Entities;
using Posts_project.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Posts_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        CommentService data = new CommentService();
        // GET: api/<CommentController>
        [HttpGet]
        public ActionResult Get()
        {
            var comments = data.Get();
            if (comments == null)
                return NotFound();
            return Ok(comments);
        }

        // GET api/<CommentController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var comment = data.GetById(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        // POST api/<CommentController>
        [HttpPost]
        public ActionResult Post([FromBody] Comment comment)
        {
            bool success = data.AddComment(comment);
            if (success)
            {
                return Ok(true);
            }
            return NotFound();
        }

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Comment comment)
        {
            bool success = data.Update(id, comment);
            if (success)
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<CommentController>/5
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
