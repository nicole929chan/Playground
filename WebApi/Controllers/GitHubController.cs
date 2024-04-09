using Microsoft.AspNetCore.Mvc;
using WebApi.GitHub.Api;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class GitHubController : ControllerBase
{
    private readonly GitHubService _gitHubService;

    public GitHubController(GitHubService gitHubService)
    {
        _gitHubService = gitHubService;
    }
    // GET: api/<GitHubController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<GitHubController>/5
    [HttpGet("{username}")]
    public async Task<IActionResult> Get(string username)
    {
        var result = await _gitHubService.GetUserAsync(username);

        return Ok(result);
    }

    // POST api/<GitHubController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<GitHubController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<GitHubController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
