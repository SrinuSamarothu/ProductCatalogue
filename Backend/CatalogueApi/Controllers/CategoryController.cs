using DataService;
using DataService.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepo repo;
        public CategoryController(IRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet("GetAll")]

        public ActionResult GetAllCategories()
        {
            var categories = repo.getAllCategories();
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
            var cat = repo.AddCategory(category);
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
            var cat = repo.UpdateCategory(category);
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
            var cat = repo.DeleteCategory(category);
            if(cat is null)
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
