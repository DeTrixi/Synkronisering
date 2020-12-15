using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Opgave2
{
    class Program
    {
        public static int Count;
        public static object Baton = new object();

        static void Main(string[] args)
        {
            Thread printStars = new Thread(PrintStars) {Name = "Stars"};
            Thread printHash = new Thread(PrintHash) {Name = "Hash"};
            printStars.Start();
            printHash.Start();

            Console.WriteLine("Hello Teacher!");
            Console.ReadLine();
        }

        private static void PrintStars(object obj)
        {
            do
            {
                lock (Baton)
                {
                    for (int i = 0; i < 60; i++)
                    {
                        Console.Write($"*");
                        Count++;
                        Thread.Sleep(10);
                    }

                    Console.WriteLine($" {Count}");
                }
            } while (true);
        }

        private static void PrintHash(object obj)
        {
            do
            {
                lock (Baton)
                {
                    for (int i = 0; i < 60; i++)
                    {
                        Console.Write($"#");
                        Count++;
                        Thread.Sleep(10);
                    }
                    Console.WriteLine($" {Count}");
                }



            } while (true);
        }
    }
}