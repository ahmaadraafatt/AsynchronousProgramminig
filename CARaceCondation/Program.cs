using System.Net.WebSockets;

namespace CARaceCondation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var wallet = new Wallet("Ahmed", 50);

            Thread t1 = new Thread(() => wallet.Debit(40));
            Thread t2 = new Thread(() => wallet.Debit(30));

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine(wallet);
            Console.ReadKey();
        }
    }
    class Wallet
    {
        private readonly object _objectLock = new object();
        public Wallet(string name, int bitcoins)
        {
            Name = name;
            Bitcoins = bitcoins;
        }

        public string Name { get; private set; }
        public int Bitcoins { get; private set; }
        public void Debit(int amount)
        {
            lock (_objectLock)
            {
                if (Bitcoins >= amount)
                {
                    Thread.Sleep(1000);
                    Bitcoins -= amount;
                }
            }
           
        }
        public void Credit(int amount)
        {
            Thread.Sleep(1000);
            Bitcoins += amount;
        }
        public override string ToString()
        {
            return $"[{Name} -> {Bitcoins} Bitcoins]";
        }
    }
}
