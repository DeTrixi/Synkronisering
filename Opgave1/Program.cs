using System;
using System.Threading;

namespace Opgave1
{
    class Program
    {
        private static int count = 0;
        private static object baton = new object();

        static void Main(string[] args)
        {
            new Thread(CountUp).Start();

            Thread.Sleep(500);
            new Thread(CountDown).Start();


            Console.WriteLine("Hello World!");
        }

        public static void CountUp(object obj)
        {
            do
            {
                Monitor.Enter(baton);

                try
                {
                    Console.WriteLine($"im in {Thread.CurrentThread.ManagedThreadId}");
                    count += 2;
                    Console.WriteLine(count);
                    Thread.Sleep(1000);
                }
                finally
                {
                    Monitor.Exit(baton);
                }
            } while (true);
        }

        public static void CountDown()
        {
            do
            {
                Monitor.Enter(baton);

                try
                {
                    Console.WriteLine($"im in {Thread.CurrentThread.ManagedThreadId}");
                    count--;
                    Console.WriteLine(count);
                    Thread.Sleep(1000);
                }
                finally
                {
                    Monitor.Exit(baton);
                }
            } while (true);
        }
    }
}