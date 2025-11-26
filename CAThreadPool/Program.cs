

internal class Program
{
    private static void Main(string[] args)
    {

        Console.WriteLine("Using ThreadPool");
        //1 Thread Pool Class
        ThreadPool.QueueUserWorkItem(new WaitCallback(Print));

        Console.WriteLine("Using Task");
        //2 Task Class
        Task.Run(Print);

        var employee = new Employee { Rate = 10, TotalHours = 40 };
        ThreadPool.QueueUserWorkItem(new WaitCallback(CalculateSalary), employee);

        Console.ReadKey();
    }

    private static void CalculateSalary(object employee)
    {
        var emp = employee as Employee;
        if (employee is null)
            return;
               emp.TotalSalary = emp.TotalHours * emp.Rate;
        Console.WriteLine(emp.TotalSalary.ToString("c"));
    }

    private static void Print()
    {
        Console.WriteLine($"Thread Name {Thread.CurrentThread.Name}, Thread id {Thread.CurrentThread.ManagedThreadId}");
        Console.WriteLine($"BackGround{Thread.CurrentThread.IsBackground}");
        Console.WriteLine($"Is Pooled {Thread.CurrentThread.IsThreadPoolThread}");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Cycle {i + 1}");
        }
    }

    private static void Print(object? state)
    {
        Console.WriteLine($"Thread Name {Thread.CurrentThread.Name}, Thread id {Thread.CurrentThread.ManagedThreadId}");
        Console.WriteLine($"BackGround{Thread.CurrentThread.IsBackground}");
        Console.WriteLine($"Is Pooled {Thread.CurrentThread.IsThreadPoolThread}");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Cycle {i + 1}");
        }
    }
    class Employee
    {

        public decimal Rate { get; set; }
        public decimal TotalHours { get; set; }
        public decimal TotalSalary { get; set; }
    }
}