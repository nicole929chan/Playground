namespace Service.Services.MementoDemo;
internal interface IEmployee
{
    int Id { get; }
    string Name { get; set; }
    int Age { get; set; }
    string Phone { get; set; }
    Memento Create();
    void Undo(Memento memento);
}
