using DataService;
using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ILogic logic;
        public CategoryController(ILogic _logic)
        {
            logic = _logic;
        }

        [HttpGet("GetAll")]
            
        public ActionResult GetAllCategories()
        {
            var categories = logic.getCategories();
            if(categories is null)
            {
                return NoContent();
            }
            else
            {
                return Ok(categories);
            }
        }

        [HttpPost("Add")]
        public ActionResult AddCategory(Category category)
        {
            var cat = logic.AddCategory(category);
            if(cat is null)
            {
                return BadRequest();
            }
            else
            {
                return Created("Add", cat);
            }
        }

        [HttpPut("Update")]
        public ActionResult EditCategory(Category category)
        {
            var cat = logic.UpdateCategory(category);
            if(cat is null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(cat);
            }
        }

        [HttpDelete("Delete")]
        public ActionResult DeleteCategory(Category category)
        {
            var cat = logic.DeleteCategory(category);
            if (cat is null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(cat);
            }
        }
    }
}
