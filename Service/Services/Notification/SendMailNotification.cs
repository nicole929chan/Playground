using Repository.Entities;

namespace Service.Services.Notification;
public class SendMailNotification : IObserver<Stock>
{
    void IObserver<Stock>.OnCompleted()
    {
        Console.WriteLine("庫存不足，已寄送通知信");
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
