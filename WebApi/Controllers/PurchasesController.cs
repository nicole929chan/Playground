using Microsoft.AspNetCore.Mvc;
using Service.Dtos;
using Service.Services;
using WebApi.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PurchasesController : ControllerBase
{
    private readonly IPurchaseService _purchaseService;

    public PurchasesController(IPurchaseService purchaseService)
    {
        _purchaseService = purchaseService;
    }
    // GET: api/<PurchasesController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<PurchasesController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var purchase = await _purchaseService.GetPurchaseByIdAsync(id);
            return purchase != null ? Ok(purchase) : NotFound();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // POST api/<PurchasesController>
    [HttpPost]
    public async Task Post([FromBody] PurchaseInfo purchaseInfo)
    {
        try
        {
            var purchaseCreate = new PurchaseCreate
            {
                PurchaseDate = purchaseInfo.PurchaseDate,
                VendorId = purchaseInfo.VendorId,
                PurchaseItems = purchaseInfo.PurchaseItems.Select(pi => new PurchaseItemCreate
                {
                    ProductId = pi.ProductId,
                    Sku = pi.Sku,
                    Quantity = pi.Quantity,
                    Price = pi.Price,
                }).ToList()
            };

            await _purchaseService.CreatePurchaseAsync(purchaseCreate);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    // PUT api/<PurchasesController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<PurchasesController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
