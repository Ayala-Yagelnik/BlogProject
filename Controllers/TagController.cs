using Microsoft.AspNetCore.Mvc;
using Posts_project.Entities;
using Posts_project.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Posts_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        TagService data=new TagService();
        // GET: api/<TagController>
        [HttpGet]
        public ActionResult Get()
        {
            var tags = data.Get();
            if (tags == null)
            {
                return NotFound();
            }
            return Ok(tags);
        }

        // GET api/<TagController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var tag = data.GetById(id);
            if (tag == null)
            {
                return NotFound();
            }
            return Ok(tag);
        }

        // POST api/<TagController>
        [HttpPost]
        public ActionResult Post([FromBody] Tag tag)
        {
            bool success = data.AddTag(tag);
            if (success)
            {
                return Ok(true);
            }
            return NotFound();
        }

        // PUT api/<TagController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Tag tag)
        {
            bool success = data.Update(id, tag);
            if (success)
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<TagController>/5
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
