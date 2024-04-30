using Repository.Entities;

namespace Service.Services.Notification;
public class StockInspector : IObservable<Stock>
{
    private readonly List<IObserver<Stock>> _observers;
    public StockInspector()
    {
        _observers = new List<IObserver<Stock>>();
    }
    public IDisposable Subscribe(IObserver<Stock> observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }

        return new Unsubscriber(_observers, observer);
    }
    public void Notify(Stock stock)
    {
        if (stock.Quantity < stock.MinimumQuantity)
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(stock);
            }
        }
    }


    private class Unsubscriber : IDisposable
    {
        private readonly List<IObserver<Stock>> _observers;
        private readonly IObserver<Stock> _observer;

        public Unsubscriber(List<IObserver<Stock>> observers, IObserver<Stock> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
            {
                _observers.Remove(_observer);
            }
        }
    }
}
