namespace Service.Services.MementoDemo;
internal class Employee : IEmployee
{
    public int Id { get; set; }
    public int Age { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }

    public Memento Create() => new Memento(Id, Name, Age, Phone);

    public void Undo(Memento memento)
    {
        Id = memento.Id;
        Name = memento.Name;
        Age = memento.Age;
        Phone = memento.Phone;
    }
}
