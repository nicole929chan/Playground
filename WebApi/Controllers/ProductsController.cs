using Microsoft.AspNetCore.Mvc;
using Service.Dtos;
using Service.Services;
using WebApi.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }
    // GET: api/<ProductsController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<ProductsController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {

            var product = await _productService.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    // POST api/<ProductsController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<ProductsController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ProductInfo productInfo)
    {
        try
        {
            var productUpdate = new ProductUpdate
            {
                Id = id,
                Name = productInfo.Name,
                Description = productInfo.Description,
                Price = productInfo.Price,
                IsDeleted = productInfo.IsDeleted
            };

            var result = await _productService.UpdateAsync(productUpdate);

            return Ok(result);
        }
        catch (Exception ex)
        {
            throw new Exception("Error in ProductsController.Put", ex);
        }

    }

    // DELETE api/<ProductsController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
