namespace CADeadLock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var wallet1 = new Wallet(20,"Ahmed", 100);
            var wallet2 = new Wallet(13,"Hamza", 50);
            Console.WriteLine("Before Transaction");
            Console.WriteLine("------------------");
            Console.Write(wallet1); Console.Write(wallet2); Console.WriteLine();
            Console.WriteLine("------------------");


            var transaction1 = new transferManager(wallet1, wallet2, 50);
            var transaction2 = new transferManager(wallet2, wallet1, 30);

            
            Thread t1 = new Thread(transaction1.transfer);
            t1.Name = "T1";
            Thread t2 = new Thread(transaction2.transfer);
            t2.Name = "T2";

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine("After Transaction");
            Console.WriteLine("------------------");
            Console.Write(wallet1); Console.Write(wallet2); Console.WriteLine();
            Console.ReadKey();
        }
    }
    class Wallet
    {
        private readonly object _objectLock = new object();
        public Wallet(int id, string name, int bitcoins)
        {
            Id = id;
            Name = name;
            Bitcoins = bitcoins;
        }
        
        public int Id { get; private set; }
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
            return $"[ {Name} -> {Bitcoins} Bitcoins] ";
        }
    }
    class transferManager
    {
        private Wallet from;
        private Wallet to;
        private int amountTransfer;

        public transferManager(Wallet from, Wallet to, int amountTransfer)
        {
            this.from = from;
            this.to = to;
            this.amountTransfer = amountTransfer;
        }

        public void transfer()
        {
          
            Console.WriteLine($"{Thread.CurrentThread.Name} trying Lock .... {from}");
            lock (from)
            {
                var lock1 = from.Id < to.Id ? from : to;
                var lock2 = from.Id < to.Id ? to : from;
                Console.WriteLine($"{Thread.CurrentThread.Name} trying Lock .... {from}");
                lock (lock1)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} locked acquired.... {from}");
                    Thread.Sleep(1000);
                    Console.WriteLine($"{Thread.CurrentThread.Name} trying Lock .... {to}");
                    lock (lock2)
                    {
                        from.Debit(amountTransfer);
                        to.Credit(amountTransfer);
                    }
                }

                //Console.WriteLine($"{Thread.CurrentThread.Name} locked acquired.... {from}");
                //Thread.Sleep(1000);
                //Console.WriteLine($"{Thread.CurrentThread.Name} trying Lock .... {to}");
                ////lock (to)
                ////{
                ////    from.Debit(amountTransfer);
                ////    to.Credit(amountTransfer);
                ////}
                //if (Monitor.TryEnter(to, 1000))
                //{
                //    Console.WriteLine($"{Thread.CurrentThread.Name} locked acquired.... {to}");
                //    try
                //    {
                //        from.Debit(amountTransfer);
                //        to.Credit(amountTransfer);
                //    }
                //    catch
                //    {

                //    }
                //    finally
                //    {
                //        Monitor.Exit(to);
                //    }
                //}
                //else
                //{
                //    Console.WriteLine($"{Thread.CurrentThread.Name} unable to acquire lock on .... {to}");
                //}

            }
        }
    }
}
