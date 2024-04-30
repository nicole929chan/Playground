using Repository.Entities;

namespace Service.Services.Notification;
public class SendMailNotification : IObserver<Stock>
{
    void IObserver<Stock>.OnCompleted()
    {
        throw new NotImplementedException();
    }

    void IObserver<Stock>.OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    void IObserver<Stock>.OnNext(Stock value)
    {
        Console.WriteLine($"Stock {value.ProductId} 庫存已低於最小數量");
    }
}
