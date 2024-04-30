using Repository.Entities;
using Service.Services.Notification;

namespace Service.Services;
public class StockService : IStockService
{
    public async Task<Stock> GetStockAsync(int productId)
    {
        StockInspector stockInspector = new();
        SendMailNotification sendMailNotification = new();
        ActivatePurchase activatePurchase = new();

        stockInspector.Subscribe(sendMailNotification);
        stockInspector.Subscribe(activatePurchase);
        Stock stock = new Stock();
        stock.ProductId = productId;
        stock.Quantity = 10;
        stock.MinimumQuantity = 20;

        stockInspector.Notify(stock);

        return stock;
    }
}
