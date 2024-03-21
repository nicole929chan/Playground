using Microsoft.AspNetCore.Mvc;
using Service.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    // GET: api/<CategoriesController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var categories = await _categoryService.GetAllAsync();

            return categories.Any() ? Ok(categories) : NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // GET api/<CategoriesController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<CategoriesController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<CategoriesController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<CategoriesController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
