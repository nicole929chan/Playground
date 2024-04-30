using Repository.Entities;

namespace Service.Services.Notification;
public class ActivatePurchase : IObserver<Stock>
{
    public void OnCompleted()
    {
        Console.WriteLine("採購單已自動新增");
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(Stock value)
    {
        Console.WriteLine($"Stock {value.ProductId} 自動新增一張採購單");
    }
}