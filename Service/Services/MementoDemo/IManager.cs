namespace Service.Services.MementoDemo;
internal interface IManager
{
    void AddMemento(int id, Memento memento);
    Memento GetMemento(int id);
}
