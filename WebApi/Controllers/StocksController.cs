using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StocksController : ControllerBase
{
    private IStockService _stockService;

    public StocksController(IStockService stockService)
    {
        _stockService = stockService;
    }
    [HttpGet]
    [Route("{productId}")]
    public async Task<IActionResult> GetByProductIdAsync(int productId)
    {
        var stock = await _stockService.GetStockAsync(productId);

        return Ok(stock);
    }
}
