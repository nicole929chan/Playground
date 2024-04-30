using Repository.Entities;
using Service.Services.Notification;

namespace Service.Services;
public class StockService : IStockService
{
    public async Task<Stock> GetStockAsync(int productId)
    {
        StockInspector stockInspector = new();
        var sendMailNotification = stockInspector.Subscribe(new SendMailNotification());
        var activatePurchase = stockInspector.Subscribe(new ActivatePurchase());
        Stock stock = new Stock();
        stock.ProductId = productId;
        stock.Quantity = 10;
        stock.MinimumQuantity = 20;

        stockInspector.Notify(stock);

        activatePurchase.Dispose();

        return stock;
    }
}
