namespace CAMultithreading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main Thread";
            Console.WriteLine(Thread.CurrentThread.Name);
            //Console.WriteLine($"BackGround Thread : {Thread.CurrentThread.IsBackground}");
            var wallet = new Wallet("Ahmed", 80);
            Console.WriteLine($"Wallet Name : {wallet.Name} || Account Balance : {wallet.Bitcoins}");
            Thread T1 = new Thread(wallet.RunRandomTransaction);
            T1.Name = "T1";
            //Console.WriteLine($"T1 BackGround Thread state is {T1.IsBackground}");
            Console.WriteLine($"after declaration {T1.Name} State is {T1.ThreadState}");


            T1.Start();
            Console.WriteLine($"after Start {T1.Name} State is {T1.ThreadState}");
            T1.Join();


            Thread T2 = new Thread(new ThreadStart(wallet.RunRandomTransaction));
            T2.Name = "T2";
            T2.Start();


            Console.WriteLine($"after Start {T1.Name} state is {T1.ThreadState}");

            Console.ReadKey();
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
                Thread.Sleep(1000);
                Bitcoins -= amount;
                Console.WriteLine(
                    $"[Thread id: {Thread.CurrentThread.ManagedThreadId} -{Thread.CurrentThread.Name}" +
                    $" Processor id: {Thread.GetCurrentProcessorId()}] - {amount}");
            }
            public void Credit(int amount)
            {
                Thread.Sleep(1000); 
                Bitcoins += amount;
                Console.WriteLine($"[Thread id: {Thread.CurrentThread.ManagedThreadId} -{Thread.CurrentThread.Name}" +
                       $" Processor id: {Thread.GetCurrentProcessorId()}] + {amount}");
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
                   
                }
            }
            public override string ToString()
            {
                return $"[{Name} -> {Bitcoins} Bitcoins]";
            }
        }
    }
}
