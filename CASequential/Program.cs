using System.Diagnostics;

namespace CASequential
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var wallet = new Wallet("Ahmed", 80);
            wallet.RunRandomTransaction();
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Wallet -> {wallet}\n");

            wallet.RunRandomTransaction();
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Wallet -> {wallet}\n");
            Console.ReadKey();
        }
    }
    class Wallet
    {
        public Wallet(string name, int bitcoins)
        {
            Name = name;
            Bitcoins = bitcoins;
        }

        public string Name { get; private set; }
        public int Bitcoins { get; private set; }
        public void Debit(int amount)
        {
            Bitcoins -= amount;
        }
        public void Credit(int amount)
        {
            Bitcoins += amount;
        }
        public void RunRandomTransaction()
        {
            int[] amounts = { 10, 20, 30, -20, -10, -10, 30, -10, 40, -20 };
            foreach (var amount in amounts)
            {
                var absValue = Math.Abs(amount);

                if (amount < 0)
                    Debit(absValue);
                else
                    Credit(absValue);
                Console.WriteLine($"[Thread id: {Thread.CurrentThread.ManagedThreadId}\t" +
                    $"Processor id: {Thread.GetCurrentProcessorId()}] {amount}");
            }
        }
        public override string ToString()
        {
            return $"[{Name} -> {Bitcoins} Bitcoins]";
        }
    }
}