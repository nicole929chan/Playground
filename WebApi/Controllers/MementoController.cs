using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MementoController : ControllerBase
{
    private readonly MementoService _mementoService;

    public MementoController(MementoService mementoService)
    {
        _mementoService = mementoService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _mementoService.Demo();
        return Ok();
    }
}
