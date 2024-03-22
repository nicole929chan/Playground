using Microsoft.AspNetCore.Mvc;
using Service.Dtos;
using Service.Services;
using WebApi.ViewModels;
using WebApi.ViewModels.Validations;

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
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var category = await _categoryService.GetByIdAsync(id);
            return category != null ? Ok(category) : NotFound();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // POST api/<CategoriesController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CategoryInfo categoryInfo)
    {
        var validator = new CategoryInfoValidator();
        var results = validator.Validate(categoryInfo);

        if (!results.IsValid)
        {
            return StatusCode(422, results.Errors);
        }

        var categoryCreate = new CategoryCreate
        {
            Name = categoryInfo.Name,
            Description = categoryInfo.Description
        };

        var category = await _categoryService.CreateAsync(categoryCreate);

        return Ok(category);
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
