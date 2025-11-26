using System.Diagnostics;

namespace CAProcesAndThread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Process id: {Process.GetCurrentProcess().Id}");
            Console.WriteLine($"Thread id: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Processor id: {Thread.GetCurrentProcessorId()}");
            Console.ReadKey();
        }
    }
}
