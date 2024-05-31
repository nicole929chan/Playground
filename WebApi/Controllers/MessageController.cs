using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MessageController : ControllerBase
{
    private readonly MessageService _messageService;

    public MessageController(MessageService messageService)
    {
        _messageService = messageService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_messageService.GetContent());
    }
}
