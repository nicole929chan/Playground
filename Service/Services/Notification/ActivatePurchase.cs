using Repository.Entities;

namespace Service.Services.Notification;
public class ActivatePurchase : IObserver<Stock>
{
    public void OnCompleted()
    {
        throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(Stock value)
    {
        Console.WriteLine($"Stock {value.ProductId} 已自動新增一張採購單");
    }
}