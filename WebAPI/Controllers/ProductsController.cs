using Microsoft.AspNetCore.Mvc;
using Services;
using Entities;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductsService _productsService;
        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get([FromQuery]int position,[FromQuery] int skip, [FromQuery] string? name, [FromQuery] string? desc,
           [FromQuery] int? minPrice, [FromQuery] int? maxPrice, [FromQuery] int?[] categoriesId)
        {

            IEnumerable<Product>  products=await _productsService.GetProducts(position, skip, name, desc, minPrice, maxPrice, categoriesId);
            if(products == null)
                return NotFound();
            return Ok(products);

        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get([FromQuery] int id)
        {
            Product product = await _productsService.GetProduct(id);
            if (product == null)
                return NotFound();
            return Ok(product);
  
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
