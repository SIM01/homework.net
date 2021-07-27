using System;
using System.Diagnostics;

namespace stage3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int numberofiterration = 999999;

            var timer = Stopwatch.StartNew();
            for (int i = 1; i <= numberofiterration; i++)
            {
                int value = rnd.Next(0, 9999);
                object box = value;
            }

            timer.Stop();
            Console.WriteLine("Выполнение упаковки заняло {0} мс", timer.ElapsedMilliseconds);

            timer = Stopwatch.StartNew();
            for (int i = 1; i <= numberofiterration; i++)
            {
                object box = (int) rnd.Next(0, 9999);
                char value = (char) (int) box;
            }

            timer.Stop();
            Console.WriteLine("Выполнение распаковки заняло {0} мс", timer.ElapsedMilliseconds);
        }
    }
}