using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogic logic;

        public ProductsController(ILogic _logic)
        {
            logic = _logic;
        }

        [HttpGet("GetAll")]

        public ActionResult GetProductsByCategory(string categoryId)
        {
            var products = logic.GetCategoryProducts(categoryId);
            if(products is null)
            {
                return NoContent();
            }
            else
            {
                return Ok(products);
            }
        }

        [HttpPost("Add")]

        public ActionResult AddProduct(Product product)
        {
            var pro = logic.AddProduct(product);
            if(pro is null)
            {
                return BadRequest();
            }
            else
            {
                return Created("Add", pro);
            }
        }

        [HttpPut("Modify")]

        public ActionResult UpdateProduct(Product product)
        {
            var pro = logic.UpdateProduct(product);
            if (pro is null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(pro);
            }
        }

        [HttpDelete("Delete")]

        public ActionResult DeleteProduct(Product product)
        {
            var pro = logic.DeleteProduct(product);
            if (pro is null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(pro);
            }
        }
    }
}
