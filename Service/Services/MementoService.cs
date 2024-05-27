namespace Service.Services;
using Service.Services.MementoDemo;
public class MementoService
{
    public void Demo()
    {
        Employee employee = new Employee
        {
            Id = 1,
            Name = "John",
            Age = 30,
            Phone = "1234567890"
        };
        IManager manager = new Manager();
        Memento memento = employee.Create();
        manager.AddMemento(employee.Id, memento); // 版本1

        employee.Name = "Doe";
        manager.AddMemento(employee.Id, employee.Create()); // 版本2
        Console.WriteLine($"Name: {employee.Name}"); // Doe

        employee.Undo(manager.GetMemento(employee.Id)); // 恢复到版本1
        Console.WriteLine($"Name: {employee.Name}"); // John
    }
}
