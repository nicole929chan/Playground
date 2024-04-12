using Microsoft.AspNetCore.Mvc;
using Service.Services.Cart.Availibility;
using WebApi.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CartController : ControllerBase
{
    // GET: api/<CartController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<CartController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<CartController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CartProductInfo request)
    {
        try
        {
            var checker = new AvailabilityService();
            var feature1 = new QuantityLimitFeature(checker);
            var feature2 = new PurchaseLimitFeature(feature1);
            var isAvailable = await feature2.IsAvailableAsync(request.ProductId, request.Quantity);

            if (isAvailable)
            {
                return Ok("Add to cart successfully");
            }
            else
            {
                return BadRequest("Failed to add to cart");
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT api/<CartController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<CartController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
