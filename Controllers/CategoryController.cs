using Microsoft.AspNetCore.Mvc;
using Posts_project.Entities;
using Posts_project.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Posts_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        CategoryService data=new CategoryService();
        // GET: api/<CategoryContoller>
        [HttpGet]
        public ActionResult Get()
        {
           var categories= data.Get();
            if (categories==null)
            {
                return NotFound();
            }
            return Ok(categories);
        }

        // GET api/<CategoryContoller>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
           var category = data.GetById(id);
            if (category==null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // POST api/<CategoryContoller>
        [HttpPost]
        public ActionResult Post([FromBody] Category category)
        {
            bool success=data.AddCategory(category);
            if (success)
            {
                return Ok(true);
            }
            return NotFound();
        }

        // PUT api/<CategoryContoller>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Category category)
        {
            bool success = data.Update(id, category);
            if (success)
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<CategoryContoller>/5
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
