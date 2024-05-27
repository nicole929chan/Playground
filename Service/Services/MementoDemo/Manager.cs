namespace Service.Services.MementoDemo;
internal class Manager : IManager
{
    private readonly Dictionary<int, Stack<Memento>> _mementos = new();
    public void AddMemento(int id, Memento memento)
    {
        if (!_mementos.ContainsKey(id))
        {
            _mementos.Add(id, new Stack<Memento>());
            _mementos[id].Push(memento);
        }
    }

    public Memento GetMemento(int id)
    {
        return _mementos[id].Pop();
    }
}
