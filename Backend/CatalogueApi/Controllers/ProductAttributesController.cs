using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAttributesController : ControllerBase
    {

        private readonly ILogic logic;

        public ProductAttributesController(ILogic _logic)
        {
            logic = _logic;
        }

        [HttpGet("GetAll")]

        public ActionResult GetAttributes(string productId)
        {
            var attributes = logic.GetProductAttributes(productId);
            if (attributes is null)
            {
                return NoContent();
            }
            else
            {
                return Ok(attributes);
            }
        }

        [HttpPost("Add")]

        public ActionResult AddAttribute(ProductAttribute productAttribute)
        {
            var att = logic.AddAttribute(productAttribute);
            if (att is null)
            {
                return BadRequest();
            }
            else
            {
                return Created("Add", att);
            }
        }

        [HttpPut("Modify")]

        public ActionResult UpdateAttribute(ProductAttribute productAttribute)
        {
            var att = logic.UpdateAttribute(productAttribute);
            if (att is null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(att);
            }
        }

        [HttpDelete("Delete")]

        public ActionResult DeleteAttribute(ProductAttribute productAttribute)
        {
            var att = logic.DeleteAttribute(productAttribute);
            if (att is null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(att);
            }
        }
    }
}
